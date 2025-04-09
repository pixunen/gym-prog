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
                _session = new InferenceSession(onnxModelPath);
            }
        }

        public ExercisePrediction Predict(ExerciseFeature input)
        {
            // Check if session is null first
            if (_session == null)
            {
                throw new InvalidOperationException("Model has not been trained or exported to ONNX format yet.");
            }

            // Create input tensor
            var inputTensor = CreateInputTensor(input);

            // Run the model
            var outputs = _session.Run(inputTensor);

            // For debugging - print all output names
            foreach (var output in outputs)
            {
                Console.WriteLine($"Output name: {output.Name}");
            }

            // Process the output
            var prediction = new ExercisePrediction();

            // Try to find outputs by name, or fall back to indices
            var setsOutput = outputs.FirstOrDefault(o => o.Name == "PredictedSets") ?? outputs[0];
            var repsOutput = outputs.FirstOrDefault(o => o.Name == "PredictedReps") ?? outputs[1];

            prediction.PredictedSets = setsOutput.AsEnumerable<float>().First();
            prediction.PredictedReps = repsOutput.AsEnumerable<float>().First();

            return prediction;
        }

        private static IReadOnlyCollection<NamedOnnxValue> CreateInputTensor(ExerciseFeature input)
        {
            // Create input for ONNX model
            var inputFeatures = new List<float>
            {
                // Exercise name encoding would expand to multiple features in one-hot encoding
                // This is simplified for illustration
                1.0f,  // Placeholder for encoded exercise name
                input.PreviousSets,
                input.PreviousReps,
                input.UserStrengthLevel,
                input.DaysSinceLastWorkout
            };

            // Create input tensor
            var tensor = new DenseTensor<float>(inputFeatures.ToArray(), new[] { 1, 5 });

            // Create named ONNX value
            return
            [
                NamedOnnxValue.CreateFromTensor("Features", tensor)
            ];
        }
    }
}
