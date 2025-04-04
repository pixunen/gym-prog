using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gym_prog.Data.Entities
{
    public record Exercise
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public required string Name { get; set; }
        public required string Description { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public required string WorkoutId { get; set; }
        public required Workout Workout { get; set; }
    }
}
