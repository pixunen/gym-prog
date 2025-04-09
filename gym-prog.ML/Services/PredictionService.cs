using System.Diagnostics;
using gym_prog.ML.Models;
using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;

namespace gym_prog.ML.Services
{
    public class PredictionService
    {
        private readonly string _modelPath;
        private readonly InferenceSession? _session;

        public PredictionService(string modelPath)
        {
            _modelPath = modelPath;

            // Load the ONNX model
            var onnxModelPath = Path.ChangeExtension(_modelPath, ".onnx");
            if (File.Exists(onnxModelPath))
            {
                try
                {
                    _session = new InferenceSession(onnxModelPath);

                    // Debug: Log the input/output names when loading the model
                    Debug.WriteLine("ONNX Model loaded successfully");
                    Debug.WriteLine("Model Inputs:");
                    foreach (var input in _session.InputMetadata)
                    {
                        Debug.WriteLine($"  Name: {input.Key}, Type: {input.Value.ElementType}, Shape: {string.Join(",", input.Value.Dimensions)}");
                    }

                    Debug.WriteLine("Model Outputs:");
                    foreach (var output in _session.OutputMetadata)
                    {
                        Debug.WriteLine($"  Name: {output.Key}, Type: {output.Value.ElementType}, Shape: {string.Join(",", output.Value.Dimensions)}");
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error loading ONNX model: {ex.Message}");
                    _session = null;
                }
            }
        }

        public ExercisePrediction Predict(ExerciseFeature input)
        {
            // If model isn't available, provide a default prediction
            if (_session == null)
            {
                return new ExercisePrediction
                {
                    PredictedSets = input.PreviousSets + 1,
                    PredictedReps = input.PreviousReps + 2
                };
            }

            try
            {
                // Get the input name from the model metadata
                string inputName = _session.InputMetadata.Keys.First();

                // Create input features - match the format used in training
                float[] features = new float[5]; // Standard size for our feature vector

                // Simple hash-based feature for exercise name
                features[0] = Math.Abs(input.ExerciseName.GetHashCode() % 1000) / 1000.0f;
                features[1] = input.PreviousSets;
                features[2] = input.PreviousReps;
                features[3] = input.UserStrengthLevel;
                features[4] = input.DaysSinceLastWorkout;

                // Get input dimensions from the model
                var shape = _session.InputMetadata[inputName].Dimensions.ToArray();

                // Create tensor with the right shape
                var tensor = new DenseTensor<float>(features, shape);

                // Create input for the model
                var inputs = new List<NamedOnnxValue>
                {
                    NamedOnnxValue.CreateFromTensor(inputName, tensor)
                };

                // Run inference
                using var results = _session.Run(inputs);

                // Get prediction from the first output
                var output = results.First();
                var prediction = output.AsEnumerable<float>().First();

                // Create prediction result with predicted sets and a reasonable rep increase
                return new ExercisePrediction
                {
                    PredictedSets = Math.Max(1, Math.Min(10, prediction)), // Clamp between 1-10 sets
                    PredictedReps = Math.Max(1, Math.Min(30, input.PreviousReps * 1.1f)) // 10% increase, capped at 30
                };
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Prediction error: {ex.Message}");

                // Fallback prediction
                return new ExercisePrediction
                {
                    PredictedSets = input.PreviousSets + 1,
                    PredictedReps = input.PreviousReps + 2
                };
            }
        }
    }
}
