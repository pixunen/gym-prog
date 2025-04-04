using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gym_prog.Data.Entities
{
    public class Workout
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public required string Name { get; set; }
        public required string Description { get; set; }
        public DateTime Date { get; set; }
        public List<Exercise> Exercises { get; set; } = [];
    }
}
