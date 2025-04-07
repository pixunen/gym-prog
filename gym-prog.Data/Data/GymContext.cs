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

            // Seed data
            SeedData(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private static void SeedData(ModelBuilder modelBuilder)
        {
            // Create workout seed data
            var workouts = new[]
            {
                new Workout
                {
                    Id = "1a2b3c4d-5e6f-7a8b-9c0d-1e2f3a4b5c6d",
                    Name = "Full Body Workout",
                    Description = "A comprehensive workout that targets all major muscle groups",
                    Date = DateTime.Now.AddDays(-7)
                },
                new Workout
                {
                    Id = "2b3c4d5e-6f7a-8b9c-0d1e-2f3a4b5c6d7e",
                    Name = "Upper Body Focus",
                    Description = "Targets chest, shoulders, back, and arms",
                    Date = DateTime.Now.AddDays(-3)
                },
                new Workout
                {
                    Id = "3c4d5e6f-7a8b-9c0d-1e2f-3a4b5c6d7e8f",
                    Name = "Lower Body Strength",
                    Description = "Focuses on quads, hamstrings, calves, and glutes",
                    Date = DateTime.Now.AddDays(-1)
                }
            };

            // Create exercise seed data
            var exercises = new[]
            {
                // Full Body Workout Exercises
                new Exercise
                {
                    Id = "1e2f3a4b-5c6d-7e8f-9a0b-1c2d3e4f5a6b",
                    Name = "Squats",
                    Description = "Compound exercise targeting quads, hamstrings, and glutes",
                    Sets = 4,
                    Reps = 12,
                    Weight = 60, // in kg
                    WorkoutId = workouts[0].Id
                },
                new Exercise
                {
                    Id = "2f3a4b5c-6d7e-8f9a-0b1c-2d3e4f5a6b7c",
                    Name = "Bench Press",
                    Description = "Compound exercise for chest, shoulders, and triceps",
                    Sets = 3,
                    Reps = 10,
                    Weight = 50, // in kg
                    WorkoutId = workouts[0].Id
                },
                new Exercise
                {
                    Id = "3a4b5c6d-7e8f-9a0b-1c2d-3e4f5a6b7c8d",
                    Name = "Deadlifts",
                    Description = "Full body compound exercise emphasizing posterior chain",
                    Sets = 4,
                    Reps = 8,
                    Weight = 80, // in kg
                    WorkoutId = workouts[0].Id
                },
                
                // Upper Body Focus Exercises
                new Exercise
                {
                    Id = "4b5c6d7e-8f9a-0b1c-2d3e-4f5a6b7c8d9e",
                    Name = "Pull-ups",
                    Description = "Bodyweight exercise targeting back and biceps",
                    Sets = 3,
                    Reps = 8,
                    Weight = 0, // bodyweight
                    WorkoutId = workouts[1].Id
                },
                new Exercise
                {
                    Id = "5c6d7e8f-9a0b-1c2d-3e4f-5a6b7c8d9e0f",
                    Name = "Shoulder Press",
                    Description = "Overhead press targeting deltoids and triceps",
                    Sets = 3,
                    Reps = 12,
                    Weight = 40, // in kg
                    WorkoutId = workouts[1].Id
                },
                new Exercise
                {
                    Id = "6d7e8f9a-0b1c-2d3e-4f5a-6b7c8d9e0f1a",
                    Name = "Bicep Curls",
                    Description = "Isolation exercise for biceps",
                    Sets = 3,
                    Reps = 15,
                    Weight = 15, // in kg
                    WorkoutId = workouts[1].Id
                },
                
                // Lower Body Strength Exercises
                new Exercise
                {
                    Id = "7e8f9a0b-1c2d-3e4f-5a6b-7c8d9e0f1a2b",
                    Name = "Leg Press",
                    Description = "Machine-based compound leg exercise",
                    Sets = 4,
                    Reps = 12,
                    Weight = 100, // in kg
                    WorkoutId = workouts[2].Id
                },
                new Exercise
                {
                    Id = "8f9a0b1c-2d3e-4f5a-6b7c-8d9e0f1a2b3c",
                    Name = "Romanian Deadlifts",
                    Description = "Targets hamstrings and lower back",
                    Sets = 3,
                    Reps = 10,
                    Weight = 70, // in kg
                    WorkoutId = workouts[2].Id
                },
                new Exercise
                {
                    Id = "9a0b1c2d-3e4f-5a6b-7c8d-9e0f1a2b3c4d",
                    Name = "Calf Raises",
                    Description = "Isolation exercise for calf muscles",
                    Sets = 4,
                    Reps = 20,
                    Weight = 30, // in kg
                    WorkoutId = workouts[2].Id
                }
            };

            // Add seed data to model builder
            modelBuilder.Entity<Workout>().HasData(workouts);
            modelBuilder.Entity<Exercise>().HasData(exercises);
        }
    }
}
