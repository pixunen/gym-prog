using gym_prog.Data.Data;
using gym_prog.ML.Models;
using Microsoft.EntityFrameworkCore;

namespace gym_prog.ML.Services
{
    public class DataPreparationService(GymContext context)
    {
        private readonly GymContext _context = context;

        public async Task<IEnumerable<ExerciseFeature>> PrepareTrainingDataAsync()
        {
            // Get all exercises
            var exercises = await _context.Exercises
                .Include(e => e.Workout)
                .OrderBy(e => e.Workout.Date)
                .ToListAsync();

            var features = new List<ExerciseFeature>();

            // Group exercises by their name to analyze progression
            var exerciseGroups = exercises.GroupBy(e => e.Name);

            foreach (var group in exerciseGroups)
            {
                var exerciseList = group.ToList();

                // Skip if there's only one record (we need at least two to see progression)
                if (exerciseList.Count < 2)
                {
                    continue;
                }

                // Create feature records for each exercise except the first one
                for (var i = 1; i < exerciseList.Count; i++)
                {
                    var current = exerciseList[i];
                    var previous = exerciseList[i - 1];

                    var daysBetween = (current.Workout.Date - previous.Workout.Date).Days;

                    features.Add(new ExerciseFeature
                    {
                        ExerciseName = current.Name,
                        PreviousSets = previous.Sets,
                        PreviousReps = previous.Reps,
                        UserStrengthLevel = current.Weight,
                        DaysSinceLastWorkout = daysBetween
                    });
                }
            }

            return features;
        }
    }
}
