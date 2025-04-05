using gym_prog.Shared.Dtos;

namespace gym_prog.Logic.Services.Interfaces
{
    public interface IWorkoutService
    {
        /// <summary>
        /// Gets all workouts from the database.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<WorkoutDto>> GetAllWorkoutsAsync();

        /// <summary>
        /// Gets a workout by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<WorkoutDto?> GetWorkoutByIdAsync(string id);

        /// <summary>
        /// Creates a new workout in the database.
        /// </summary>
        /// <param name="workoutDto"></param>
        /// <returns></returns>
        Task<WorkoutDto> CreateWorkoutAsync(WorkoutDto workoutDto);

        /// <summary>
        /// Updates an existing workout in the database.
        /// </summary>
        /// <param name="workoutDto"></param>
        /// <returns></returns>
        Task<bool> UpdateWorkoutAsync(WorkoutDto workoutDto);

        /// <summary>
        /// Deletes a workout from the database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteWorkoutAsync(string id);
    }
}
