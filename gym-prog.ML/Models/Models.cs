using Microsoft.ML.Data;

namespace gym_prog.ML.Models
{
    // Input features for our model
    public class ExerciseFeature
    {
        [LoadColumn(0)]
        public string ExerciseName { get; set; } = string.Empty;

        [LoadColumn(1)]
        public float PreviousSets { get; set; }

        [LoadColumn(2)]
        public float PreviousReps { get; set; }

        [LoadColumn(3)]
        public float UserStrengthLevel { get; set; } // Using weight as a proxy for strength level

        [LoadColumn(4)]
        public float DaysSinceLastWorkout { get; set; }
    }

    // Prediction output
    public class ExercisePrediction
    {
        [ColumnName("Score")]
        public float PredictedSets { get; set; }

        // Not directly predicted by the model but calculated in the service
        public float PredictedReps { get; set; }
    }
}
