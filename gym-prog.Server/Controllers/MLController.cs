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
                _logger.LogInformation("Making prediction for exercise: {ExerciseName}", input.ExerciseName);

                // Check if the model exists before attempting prediction
                var modelPath = Path.Combine(Environment.CurrentDirectory, "Data", "GymProgressionModel.zip");
                var onnxModelPath = Path.ChangeExtension(modelPath, ".onnx");
                bool modelExists = System.IO.File.Exists(onnxModelPath);

                if (!modelExists)
                {
                    _logger.LogWarning("Model has not been trained yet. Using simple progression for {ExerciseName}", input.ExerciseName);

                    // Return a fallback prediction with a flag indicating it's not from the model
                    return Ok(new
                    {
                        PredictedSets = input.PreviousSets + 1,
                        PredictedReps = input.PreviousReps + 2,
                        PredictedWeight = input.UserStrengthLevel < 5 ? input.UserStrengthLevel + 2.5f : Math.Round(input.UserStrengthLevel * 1.05),
                        IsModelPrediction = false,
                        Message = "Model has not been trained yet. Using simple progression."
                    });
                }

                // Handle edge cases with default values
                if (input.PreviousSets <= 0)
                {
                    input.PreviousSets = 3;
                }

                if (input.PreviousReps <= 0)
                {
                    input.PreviousReps = 10;
                }

                if (input.UserStrengthLevel <= 0)
                {
                    input.UserStrengthLevel = 1;
                }

                if (input.DaysSinceLastWorkout <= 0)
                {
                    input.DaysSinceLastWorkout = 1;
                }

                var prediction = _predictionService.Predict(input);

                // Ensure predictions are reasonable
                prediction.PredictedSets = Math.Min(Math.Max(1, prediction.PredictedSets), input.PreviousSets + 2);
                prediction.PredictedReps = Math.Min(Math.Max(1, prediction.PredictedReps), input.PreviousReps + 5);

                // Calculate a recommended weight (simple 5% increase as the model doesn't predict weight)
                var predictedWeight = input.UserStrengthLevel < 5 ?
                    input.UserStrengthLevel + 2.5f :
                    (float)Math.Round(input.UserStrengthLevel * 1.05);

                _logger.LogInformation("Prediction result: Sets={Sets}, Reps={Reps}, Weight={Weight}",
                    prediction.PredictedSets, prediction.PredictedReps, predictedWeight);

                return Ok(new
                {
                    prediction.PredictedSets,
                    prediction.PredictedReps,
                    PredictedWeight = predictedWeight,
                    IsModelPrediction = true
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error making prediction");

                // Provide a fallback prediction if the model fails
                return Ok(new
                {
                    PredictedSets = input.PreviousSets + 1,
                    PredictedReps = input.PreviousReps + 2,
                    PredictedWeight = input.UserStrengthLevel < 5 ? input.UserStrengthLevel + 2.5f : Math.Round(input.UserStrengthLevel * 1.05),
                    IsModelPrediction = false,
                    Message = "Error making prediction. Using simple progression."
                });
            }
        }

        [HttpGet("train-status")]
        public IActionResult GetTrainingStatus()
        {
            try
            {
                var modelPath = Path.Combine(Environment.CurrentDirectory, "Data", "GymProgressionModel.zip");
                var onnxModelPath = Path.ChangeExtension(modelPath, ".onnx");

                var status = new
                {
                    ModelTrained = System.IO.File.Exists(modelPath),
                    OnnxExported = System.IO.File.Exists(onnxModelPath),
                    LastTrainedUtc = System.IO.File.Exists(modelPath)
                        ? (DateTime?)System.IO.File.GetLastWriteTimeUtc(modelPath)
                        : null
                };

                return Ok(status);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error checking model status");
                return StatusCode(500, "Error checking model status: " + ex.Message);
            }
        }
    }
}
