using Microsoft.AspNetCore.Mvc;
using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;

namespace gym_prog.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OnnxDebugController : ControllerBase
    {
        private readonly ILogger<OnnxDebugController> _logger;

        public OnnxDebugController(ILogger<OnnxDebugController> logger)
        {
            _logger = logger;
        }

        [HttpGet("inspect")]
        public IActionResult InspectOnnxModel()
        {
            try
            {
                // Define path to the ONNX model
                var modelPath = Path.Combine(Environment.CurrentDirectory, "Data", "GymProgressionModel.onnx");

                if (!System.IO.File.Exists(modelPath))
                {
                    return NotFound($"ONNX model not found at: {modelPath}");
                }

                // Load the model
                var session = new InferenceSession(modelPath);

                // Prepare result object
                var result = new
                {
                    ModelPath = modelPath,
                    Inputs = session.InputMetadata.Select(i => new
                    {
                        Name = i.Key,
                        Type = i.Value.ElementType.ToString(),
                        Shape = i.Value.Dimensions
                    }).ToList(),
                    Outputs = session.OutputMetadata.Select(o => new
                    {
                        Name = o.Key,
                        Type = o.Value.ElementType.ToString(),
                        Shape = o.Value.Dimensions
                    }).ToList()
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error inspecting ONNX model");
                return StatusCode(500, $"Error inspecting ONNX model: {ex.Message}");
            }
        }

        [HttpPost("test-inference")]
        public IActionResult TestInference([FromBody] TestInferenceRequest request)
        {
            try
            {
                // Define path to the ONNX model
                var modelPath = Path.Combine(Environment.CurrentDirectory, "Data", "GymProgressionModel.onnx");

                if (!System.IO.File.Exists(modelPath))
                {
                    return NotFound($"ONNX model not found at: {modelPath}");
                }

                // Load the model
                var session = new InferenceSession(modelPath);

                // Get input info
                var inputMeta = session.InputMetadata.First();
                var inputName = inputMeta.Key;
                var inputShape = inputMeta.Value.Dimensions.ToArray();

                // Create input tensor
                var inputData = request.InputValues;

                // If the input data doesn't match the expected shape, resize it
                if (inputData.Length != inputShape.Aggregate(1, (acc, dim) => acc * (int)dim))
                {
                    // Simple resize strategy - truncate or pad with zeros
                    Array.Resize(ref inputData, inputShape.Aggregate(1, (acc, dim) => acc * (int)dim));
                }

                var tensor = new DenseTensor<float>(inputData, inputShape);
                var inputs = new List<NamedOnnxValue> { NamedOnnxValue.CreateFromTensor(inputName, tensor) };

                // Run inference
                var outputs = session.Run(inputs);

                // Collect results
                var results = new Dictionary<string, float[]>();
                foreach (var output in outputs)
                {
                    results[output.Name] = output.AsEnumerable<float>().ToArray();
                }

                return Ok(new
                {
                    InputName = inputName,
                    InputShape = inputShape,
                    InputValues = inputData,
                    Outputs = results
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error testing ONNX inference");
                return StatusCode(500, $"Error testing ONNX inference: {ex.Message}");
            }
        }
    }

    public class TestInferenceRequest
    {
        public float[] InputValues { get; set; } = Array.Empty<float>();
    }
}
