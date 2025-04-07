namespace gym_prog.Shared.Dtos
{
    public class ExerciseDto
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Sets { get; set; }
        public int Reps { get; set; }
        public int Weight { get; set; } // in kg
        public string WorkoutId { get; set; } = string.Empty;
    }
}
