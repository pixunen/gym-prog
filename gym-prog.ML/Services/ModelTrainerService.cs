using System.Diagnostics;
using gym_prog.ML.Models;
using Microsoft.ML;

namespace gym_prog.ML.Services
{
    public class ModelTrainerService(string modelSavePath)
    {
        private readonly MLContext _mlContext = new(seed: 0);
        private readonly string _modelPath = modelSavePath;

        public ITransformer TrainAndSaveModel(IEnumerable<ExerciseFeature> trainingData)
        {
            // Convert training data to IDataView
            var trainingDataView = _mlContext.Data.LoadFromEnumerable(trainingData);

            // Define the pipeline for processing the data
            // First convert the string column to numeric representation
            var pipeline = _mlContext.Transforms.Categorical.OneHotEncoding("ExerciseNameEncoded", "ExerciseName")
                // Combine all feature columns
                .Append(_mlContext.Transforms.Concatenate("Features",
                    "ExerciseNameEncoded",
                    nameof(ExerciseFeature.PreviousSets),
                    nameof(ExerciseFeature.PreviousReps),
                    nameof(ExerciseFeature.UserStrengthLevel),
                    nameof(ExerciseFeature.DaysSinceLastWorkout)))
                // Set the label column (what we're trying to predict)
                .Append(_mlContext.Transforms.CopyColumns("Label", nameof(ExerciseFeature.PreviousSets)))
                // Train a regression model
                .Append(_mlContext.Regression.Trainers.FastTree());

            // Train the model
            Debug.WriteLine("Training the ML model...");
            var model = pipeline.Fit(trainingDataView);
            Debug.WriteLine("Model training completed successfully.");

            // Save the model
            _mlContext.Model.Save(model, trainingDataView.Schema, _modelPath);
            Debug.WriteLine($"Model saved to: {_modelPath}");

            return model;
        }

        public void ExportToOnnx(ITransformer model, IEnumerable<ExerciseFeature> representativeData)
        {
            try
            {
                // We need sample data to trace the model execution
                var dataView = _mlContext.Data.LoadFromEnumerable(representativeData);

                // Define the path for the ONNX model
                var onnxModelPath = Path.ChangeExtension(_modelPath, ".onnx");

                // For debugging
                Debug.WriteLine($"Exporting model to ONNX format at: {onnxModelPath}");

                // Convert to ONNX format
                using var stream = File.Create(onnxModelPath);
                _mlContext.Model.ConvertToOnnx(model, dataView, stream);
                Debug.WriteLine("ONNX model export completed successfully.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error exporting to ONNX: {ex.Message}");
                throw;
            }
        }
    }
}
