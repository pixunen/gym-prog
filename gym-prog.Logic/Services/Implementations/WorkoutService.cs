using gym_prog.Data.Data;
using gym_prog.Data.Entities;
using gym_prog.Logic.Mapping;
using gym_prog.Logic.Services.Interfaces;
using gym_prog.Shared.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace gym_prog.Logic.Services.Implementations
{
    public class WorkoutService(GymContext context, ILogger<WorkoutService> logger) : IWorkoutService
    {
        private readonly GymContext _context = context;
        private readonly ILogger<WorkoutService> _logger = logger;

        public async Task<IEnumerable<WorkoutDto>> GetAllWorkoutsAsync()
        {
            try
            {
                _logger.LogInformation("Retrieving all workouts");

                var workouts = await _context.Workouts
                    .Include(w => w.Exercises)
                    .OrderByDescending(w => w.Date)
                    .ToListAsync();

                // Use our simple mapper extension method
                return workouts.ToDtos();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving workouts: {Message}", ex.Message);
                throw;
            }
        }

        public async Task<WorkoutDto?> GetWorkoutByIdAsync(string id)
        {
            var workout = await _context.Workouts
                .Include(w => w.Exercises)
                .FirstOrDefaultAsync(w => w.Id == id);

            return workout?.ToDto();
        }

        public async Task<WorkoutDto> CreateWorkoutAsync(WorkoutDto workoutDto)
        {
            // Convert DTO to entity
            var workout = workoutDto.ToEntity() ?? throw new ArgumentNullException(nameof(workoutDto), "Workout DTO cannot be null");

            // Generate a new ID
            workout.Id = Guid.NewGuid().ToString();

            // Clear the exercise IDs and set workout relationship
            foreach (var exercise in workout.Exercises)
            {
                exercise.Id = Guid.NewGuid().ToString();
                exercise.WorkoutId = workout.Id;
            }

            _context.Workouts.Add(workout);
            await _context.SaveChangesAsync();

            // Convert back to DTO with a null check
            return workout.ToDto() ?? throw new InvalidOperationException("Failed to convert entity to DTO");
        }

        public async Task<bool> UpdateWorkoutAsync(WorkoutDto workoutDto)
        {
            // First check if workout exists
            var existingWorkout = await _context.Workouts
                .Include(w => w.Exercises)
                .FirstOrDefaultAsync(w => w.Id == workoutDto.Id);

            if (existingWorkout == null)
            {
                return false;
            }

            // Update basic workout properties
            existingWorkout.Name = workoutDto.Name;
            existingWorkout.Description = workoutDto.Description;
            existingWorkout.Date = workoutDto.Date;

            // Remove existing exercises
            _context.Exercises.RemoveRange(existingWorkout.Exercises);

            // Add updated exercises
            existingWorkout.Exercises = [.. workoutDto.Exercises
                .Select(e => new Exercise
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = e.Name,
                    Description = e.Description,
                    Sets = e.Sets,
                    Reps = e.Reps,
                    WorkoutId = existingWorkout.Id,
                    Workout = existingWorkout
                })];

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteWorkoutAsync(string id)
        {
            var workout = await _context.Workouts.FindAsync(id);
            if (workout == null)
            {
                return false;
            }

            _context.Workouts.Remove(workout);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
