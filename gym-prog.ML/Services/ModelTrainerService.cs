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

            // Define the pipeline
            var pipeline = _mlContext.Transforms.Categorical.OneHotEncoding("ExerciseNameEncoded", "ExerciseName")
                .Append(_mlContext.Transforms.Concatenate("Features",
                    "ExerciseNameEncoded", "PreviousSets", "PreviousReps", "UserStrengthLevel", "DaysSinceLastWorkout"))
                .Append(_mlContext.Transforms.CopyColumns("Label", "PreviousSets"))
                .Append(_mlContext.Regression.Trainers.FastTree());

            // Train the model
            var model = pipeline.Fit(trainingDataView);

            // Save the model
            _mlContext.Model.Save(model, trainingDataView.Schema, _modelPath);

            return model;
        }

        public void ExportToOnnx(ITransformer model, IEnumerable<ExerciseFeature> representativeData)
        {
            // We need sample data to trace the model execution
            var dataView = _mlContext.Data.LoadFromEnumerable(representativeData);

            // Define the path for the ONNX model
            var onnxModelPath = Path.ChangeExtension(_modelPath, ".onnx");

            // Convert to ONNX format
            using var stream = File.Create(onnxModelPath);
            _mlContext.Model.ConvertToOnnx(model, dataView, stream);
        }
    }
}
