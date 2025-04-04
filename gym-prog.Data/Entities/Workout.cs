namespace gym_prog.Data.Entities
{
    public record Workout
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public required string Name { get; set; }
        public required string Description { get; set; }
        public DateTime Date { get; set; }
        public List<Exercise> Exercises { get; set; } = [];
    }
}
