using gym_prog.ML.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace gym_prog.Server.Services
{
    public class BackgroundTrainingService(
        IServiceScopeFactory scopeFactory,
        ILogger<BackgroundTrainingService> logger) : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory = scopeFactory;
        private readonly ILogger<BackgroundTrainingService> _logger = logger;
        private readonly TimeSpan _interval = TimeSpan.FromHours(24); // Train once a day by default

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Background Training Service is starting.");

            using var timer = new PeriodicTimer(_interval);

            try
            {
                // Run immediately on startup
                await TrainModelAsync();

                // Then run on the timer
                while (await timer.WaitForNextTickAsync(stoppingToken))
                {
                    await TrainModelAsync();
                }
            }
            catch (Exception ex) when (ex is not OperationCanceledException)
            {
                _logger.LogError(ex, "An error occurred in the background training service.");
            }

            _logger.LogInformation("Background Training Service is stopping.");
        }

        private async Task TrainModelAsync()
        {
            try
            {
                _logger.LogInformation("Starting scheduled model training.");

                using var scope = _scopeFactory.CreateScope();
                var dataPreparationService = scope.ServiceProvider.GetRequiredService<DataPreparationService>();
                var modelTrainerService = scope.ServiceProvider.GetRequiredService<ModelTrainerService>();

                var trainingData = await dataPreparationService.PrepareTrainingDataAsync();

                if (!trainingData.Any())
                {
                    _logger.LogWarning("Not enough data to train the model.");
                    return;
                }

                var model = modelTrainerService.TrainAndSaveModel(trainingData);
                modelTrainerService.ExportToOnnx(model, trainingData.Take(1));

                _logger.LogInformation("Scheduled model training completed successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during scheduled model training.");
            }
        }
    }
}
