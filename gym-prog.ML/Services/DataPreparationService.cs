using gym_prog.Data.Data;
using gym_prog.ML.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace gym_prog.ML.Services
{
    public class DataPreparationService(GymContext context, ILogger<DataPreparationService> logger)
    {
        private readonly GymContext _context = context;
        private readonly ILogger<DataPreparationService> _logger = logger;

        public async Task<IEnumerable<ExerciseFeature>> PrepareTrainingDataAsync()
        {
            try
            {
                _logger.LogInformation("Preparing training data for ML model");

                // Get all exercises
                var exercises = await _context.Exercises
                    .Include(e => e.Workout)
                    .Where(e => e.Workout != null)  // Only include exercises with a workout
                    .OrderBy(e => e.Workout!.Date)  // Use null-forgiving operator since we've filtered
                    .ToListAsync();

                _logger.LogInformation("Found {ExerciseCount} exercises for training data preparation", exercises.Count);

                var features = new List<ExerciseFeature>();

                // Group exercises by their name to analyze progression
                var exerciseGroups = exercises.GroupBy(e => e.Name);

                foreach (var group in exerciseGroups)
                {
                    var exerciseList = group.ToList();

                    // Skip if there's only one record (we need at least two to see progression)
                    if (exerciseList.Count < 2)
                    {
                        _logger.LogInformation("Skipping exercise {ExerciseName} - only {Count} instance(s)",
                            group.Key, exerciseList.Count);
                        continue;
                    }

                    _logger.LogInformation("Processing {Count} instances of {ExerciseName}",
                        exerciseList.Count, group.Key);

                    // Create feature records for each exercise except the first one
                    for (var i = 1; i < exerciseList.Count; i++)
                    {
                        var current = exerciseList[i];
                        var previous = exerciseList[i - 1];

                        // Both current and previous should have non-null Workout because of our filter above
                        // But we'll add a safety check anyway
                        if (current.Workout == null || previous.Workout == null)
                        {
                            _logger.LogWarning("Skipping a record for {ExerciseName} due to null workout reference",
                                current.Name);
                            continue;  // Skip this iteration if either workout is null
                        }

                        var daysBetween = (current.Workout.Date - previous.Workout.Date).Days;

                        features.Add(new ExerciseFeature
                        {
                            ExerciseName = current.Name,
                            PreviousSets = previous.Sets,
                            PreviousReps = previous.Reps,
                            UserStrengthLevel = current.Weight > 0 ? current.Weight : 1,
                            DaysSinceLastWorkout = daysBetween > 0 ? daysBetween : 1
                        });
                    }
                }

                _logger.LogInformation("Successfully prepared {FeatureCount} training features", features.Count);
                return features;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error preparing training data");
                throw;
            }
        }
    }
}
