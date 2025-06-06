using gym_prog.Logic.Services.Interfaces;
using gym_prog.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace gym_prog.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkoutController(ILogger<WorkoutController> logger, IWorkoutService workoutService) : ControllerBase
    {
        private readonly ILogger<WorkoutController> _logger = logger;
        private readonly IWorkoutService _workoutService = workoutService;

        [HttpGet(Name = "GetWorkouts")]
        public async Task<IEnumerable<WorkoutDto>> Get()
        {
            _logger.LogInformation("Getting all workouts");
            return await _workoutService.GetAllWorkoutsAsync();
        }
    }
}
