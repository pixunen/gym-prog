namespace gym_prog.Shared.Dtos
{
    public class WorkoutDto
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public List<ExerciseDto> Exercises { get; set; } = [];
    }
}
