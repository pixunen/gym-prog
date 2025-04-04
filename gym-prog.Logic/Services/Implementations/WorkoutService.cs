using gym_prog.Data.Entities;
using gym_prog.Logic.Services.Interfaces;

namespace gym_prog.Logic.Services.Implementations
{
    public class WorkoutService : IWorkoutService
    {
        public Task<IEnumerable<Workout>> GetAllWorkoutsAsync()
        {
            return Task.FromResult<IEnumerable<Workout>>(
            [
                new() {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Leg Day",
                    Description = "A workout focused on legs.",
                    Date = DateTime.Now,
                    Exercises =
                    [
                        new Exercise { Id = Guid.NewGuid().ToString(), Name = "Squats", Description = "This was hard", Sets = 4, Reps = 10 },
                        new Exercise { Id = Guid.NewGuid().ToString(), Name = "Lunges", Description = "This was hard",Sets = 3, Reps = 12 }
                    ]
                },
                new() {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Chest Day",
                    Description = "A workout focused on chest.",
                    Date = DateTime.Now,
                    Exercises =
                    [
                        new Exercise { Id = Guid.NewGuid().ToString(), Name = "Bench Press", Description = "This was hard", Sets = 4, Reps = 8 },
                        new Exercise { Id = Guid.NewGuid().ToString(), Name = "Push Ups", Description = "This was not hard", Sets = 3, Reps = 15 }
                    ]
                }
            ]);
        }
    }
}
