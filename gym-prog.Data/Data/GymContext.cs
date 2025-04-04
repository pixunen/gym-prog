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
            // Configure Workout entity
            modelBuilder.Entity<Workout>()
                .Property(w => w.Id)
                .HasDefaultValueSql("NEWID()");

            // Configure Exercise entity
            modelBuilder.Entity<Exercise>()
                .Property(e => e.Id)
                .HasDefaultValueSql("NEWID()");

            // Configure relationship
            modelBuilder.Entity<Workout>()
                .HasMany(w => w.Exercises)
                .WithOne(e => e.Workout)
                .HasForeignKey(e => e.WorkoutId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
