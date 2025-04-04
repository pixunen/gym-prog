using gym_prog.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace gym_prog.Data.Data
{
    public class GymContext : DbContext
    {
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<Exercise> Exercises { get; set; }

        public GymContext(DbContextOptions<GymContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Workout>()
                .HasMany(w => w.Exercises)
                .WithOne(e => e.Workout)
                .HasForeignKey(e => e.WorkoutId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
