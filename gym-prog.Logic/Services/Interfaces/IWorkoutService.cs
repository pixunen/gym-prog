using gym_prog.Data.Entities;

namespace gym_prog.Logic.Services.Interfaces
{
    public interface IWorkoutService
    {
        Task<IEnumerable<Workout>> GetAllWorkoutsAsync();
    }
}
