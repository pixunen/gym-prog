using gym_prog.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace gym_prog.Data.Data
{
    public class GymContext(DbContextOptions<GymContext> options) : DbContext(options)
    {
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<Exercise> Exercises { get; set; }

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
