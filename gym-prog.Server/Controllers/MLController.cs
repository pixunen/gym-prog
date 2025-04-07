using gym_prog.ML.Models;
using gym_prog.ML.Services;
using Microsoft.AspNetCore.Mvc;

namespace gym_prog.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MLController(
        DataPreparationService dataPreparationService,
        ModelTrainerService modelTrainerService,
        PredictionService predictionService,
        ILogger<MLController> logger) : ControllerBase
    {
        private readonly DataPreparationService _dataPreparationService = dataPreparationService;
        private readonly ModelTrainerService _modelTrainerService = modelTrainerService;
        private readonly PredictionService _predictionService = predictionService;
        private readonly ILogger<MLController> _logger = logger;

        [HttpPost("train")]
        public async Task<IActionResult> Train()
        {
            try
            {
                var trainingData = await _dataPreparationService.PrepareTrainingDataAsync();

                if (!trainingData.Any())
                {
                    return BadRequest("Not enough data to train the model");
                }

                var model = _modelTrainerService.TrainAndSaveModel(trainingData);
                _modelTrainerService.ExportToOnnx(model, trainingData.Take(1));

                return Ok("Model trained and saved successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error training model");
                return StatusCode(500, "Error training model: " + ex.Message);
            }
        }

        [HttpPost("predict")]
        public IActionResult Predict([FromBody] ExerciseFeature input)
        {
            try
            {
                var prediction = _predictionService.Predict(input);
                return Ok(prediction);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error making prediction");
                return StatusCode(500, "Error making prediction: " + ex.Message);
            }
        }
    }
}
