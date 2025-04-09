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
            // Create workout seed data - Create a more comprehensive history (previous 3 months)
            var now = DateTime.Now;
            var workouts = new[]
            {
                // Month 1 - Starting point (12 weeks ago)
                new Workout
                {
                    Id = "workout-m1-w1",
                    Name = "Full Body Workout",
                    Description = "A comprehensive workout that targets all major muscle groups",
                    Date = now.AddDays(-84) // 12 weeks ago
                },
                new Workout
                {
                    Id = "workout-m1-w2",
                    Name = "Upper Body Focus",
                    Description = "Targets chest, shoulders, back, and arms",
                    Date = now.AddDays(-80) // A few days later
                },
                new Workout
                {
                    Id = "workout-m1-w3",
                    Name = "Lower Body Strength",
                    Description = "Focuses on quads, hamstrings, calves, and glutes",
                    Date = now.AddDays(-77) // A few days later
                },
        
                // Month 1 - Week 2
                new Workout
                {
                    Id = "workout-m1-w4",
                    Name = "Full Body Workout",
                    Description = "A comprehensive workout that targets all major muscle groups",
                    Date = now.AddDays(-70) // 10 weeks ago
                },
                new Workout
                {
                    Id = "workout-m1-w5",
                    Name = "Upper Body Focus",
                    Description = "Targets chest, shoulders, back, and arms",
                    Date = now.AddDays(-66)
                },
                new Workout
                {
                    Id = "workout-m1-w6",
                    Name = "Lower Body Strength",
                    Description = "Focuses on quads, hamstrings, calves, and glutes",
                    Date = now.AddDays(-63)
                },
        
                // Month 2 - Week 1 (8 weeks ago)
                new Workout
                {
                    Id = "workout-m2-w1",
                    Name = "Full Body Workout",
                    Description = "A comprehensive workout that targets all major muscle groups",
                    Date = now.AddDays(-56) // 8 weeks ago
                },
                new Workout
                {
                    Id = "workout-m2-w2",
                    Name = "Upper Body Focus",
                    Description = "Targets chest, shoulders, back, and arms",
                    Date = now.AddDays(-52)
                },
                new Workout
                {
                    Id = "workout-m2-w3",
                    Name = "Lower Body Strength",
                    Description = "Focuses on quads, hamstrings, calves, and glutes",
                    Date = now.AddDays(-49)
                },
        
                // Month 2 - Week 2
                new Workout
                {
                    Id = "workout-m2-w4",
                    Name = "Full Body Workout",
                    Description = "A comprehensive workout that targets all major muscle groups",
                    Date = now.AddDays(-42) // 6 weeks ago
                },
                new Workout
                {
                    Id = "workout-m2-w5",
                    Name = "Upper Body Focus",
                    Description = "Targets chest, shoulders, back, and arms",
                    Date = now.AddDays(-38)
                },
                new Workout
                {
                    Id = "workout-m2-w6",
                    Name = "Lower Body Strength",
                    Description = "Focuses on quads, hamstrings, calves, and glutes",
                    Date = now.AddDays(-35)
                },
        
                // Month 3 - Week 1 (4 weeks ago)
                new Workout
                {
                    Id = "workout-m3-w1",
                    Name = "Full Body Workout",
                    Description = "A comprehensive workout that targets all major muscle groups",
                    Date = now.AddDays(-28) // 4 weeks ago
                },
                new Workout
                {
                    Id = "workout-m3-w2",
                    Name = "Upper Body Focus",
                    Description = "Targets chest, shoulders, back, and arms",
                    Date = now.AddDays(-24)
                },
                new Workout
                {
                    Id = "workout-m3-w3",
                    Name = "Lower Body Strength",
                    Description = "Focuses on quads, hamstrings, calves, and glutes",
                    Date = now.AddDays(-21)
                },
        
                // Month 3 - Week 2
                new Workout
                {
                    Id = "workout-m3-w4",
                    Name = "Full Body Workout",
                    Description = "A comprehensive workout that targets all major muscle groups",
                    Date = now.AddDays(-14) // 2 weeks ago
                },
                new Workout
                {
                    Id = "workout-m3-w5",
                    Name = "Upper Body Focus",
                    Description = "Targets chest, shoulders, back, and arms",
                    Date = now.AddDays(-10)
                },
                new Workout
                {
                    Id = "workout-m3-w6",
                    Name = "Lower Body Strength",
                    Description = "Focuses on quads, hamstrings, calves, and glutes",
                    Date = now.AddDays(-7) // 1 week ago
                },
        
                // Current Week
                new Workout
                {
                    Id = "1a2b3c4d-5e6f-7a8b-9c0d-1e2f3a4b5c6d", // Keep the ID from the current seed for consistency
                    Name = "Full Body Workout",
                    Description = "A comprehensive workout that targets all major muscle groups",
                    Date = now.AddDays(-3) // 3 days ago
                },
                new Workout
                {
                    Id = "2b3c4d5e-6f7a-8b9c-0d1e-2f3a4b5c6d7e", // Keep the ID from the current seed for consistency
                    Description = "Targets chest, shoulders, back, and arms",
                    Name = "Upper Body Focus",
                    Date = now.AddDays(-1) // Yesterday
                },
                new Workout
                {
                    Id = "3c4d5e6f-7a8b-9c0d-1e2f-3a4b5c6d7e8f", // Keep the ID from the current seed for consistency
                    Name = "Lower Body Strength",
                    Description = "Focuses on quads, hamstrings, calves, and glutes",
                    Date = now // Today
                }
            };

            // Exercise data with progression
            var exercises = new List<Exercise>();

            // Helper method to generate progression
            Exercise CreateExercise(string id, string name, string description, int sets, int reps, int weight, string workoutId)
            {
                return new Exercise
                {
                    Id = id,
                    Name = name,
                    Description = description,
                    Sets = sets,
                    Reps = reps,
                    Weight = weight,
                    WorkoutId = workoutId
                };
            }

            // SQUAT PROGRESSION
            // Month 1
            exercises.Add(CreateExercise("squat-m1-w1", "Squats", "Compound exercise targeting quads, hamstrings, and glutes", 3, 8, 40, "workout-m1-w1"));
            exercises.Add(CreateExercise("squat-m1-w3", "Squats", "Compound exercise targeting quads, hamstrings, and glutes", 3, 10, 40, "workout-m1-w3"));
            exercises.Add(CreateExercise("squat-m1-w4", "Squats", "Compound exercise targeting quads, hamstrings, and glutes", 3, 12, 40, "workout-m1-w4"));
            exercises.Add(CreateExercise("squat-m1-w6", "Squats", "Compound exercise targeting quads, hamstrings, and glutes", 4, 8, 45, "workout-m1-w6"));

            // Month 2
            exercises.Add(CreateExercise("squat-m2-w1", "Squats", "Compound exercise targeting quads, hamstrings, and glutes", 4, 10, 45, "workout-m2-w1"));
            exercises.Add(CreateExercise("squat-m2-w3", "Squats", "Compound exercise targeting quads, hamstrings, and glutes", 4, 12, 45, "workout-m2-w3"));
            exercises.Add(CreateExercise("squat-m2-w4", "Squats", "Compound exercise targeting quads, hamstrings, and glutes", 4, 8, 50, "workout-m2-w4"));
            exercises.Add(CreateExercise("squat-m2-w6", "Squats", "Compound exercise targeting quads, hamstrings, and glutes", 4, 10, 50, "workout-m2-w6"));

            // Month 3
            exercises.Add(CreateExercise("squat-m3-w1", "Squats", "Compound exercise targeting quads, hamstrings, and glutes", 4, 12, 50, "workout-m3-w1"));
            exercises.Add(CreateExercise("squat-m3-w3", "Squats", "Compound exercise targeting quads, hamstrings, and glutes", 4, 10, 55, "workout-m3-w3"));
            exercises.Add(CreateExercise("squat-m3-w4", "Squats", "Compound exercise targeting quads, hamstrings, and glutes", 4, 12, 55, "workout-m3-w4"));
            exercises.Add(CreateExercise("squat-m3-w6", "Squats", "Compound exercise targeting quads, hamstrings, and glutes", 4, 12, 60, "workout-m3-w6"));

            // Current week - keep the existing ID from the current seed data
            exercises.Add(CreateExercise("1e2f3a4b-5c6d-7e8f-9a0b-1c2d3e4f5a6b", "Squats", "Compound exercise targeting quads, hamstrings, and glutes", 4, 12, 60, "1a2b3c4d-5e6f-7a8b-9c0d-1e2f3a4b5c6d"));

            // BENCH PRESS PROGRESSION
            // Month 1
            exercises.Add(CreateExercise("bench-m1-w1", "Bench Press", "Compound exercise for chest, shoulders, and triceps", 3, 8, 30, "workout-m1-w1"));
            exercises.Add(CreateExercise("bench-m1-w2", "Bench Press", "Compound exercise for chest, shoulders, and triceps", 3, 10, 30, "workout-m1-w2"));
            exercises.Add(CreateExercise("bench-m1-w4", "Bench Press", "Compound exercise for chest, shoulders, and triceps", 3, 12, 30, "workout-m1-w4"));
            exercises.Add(CreateExercise("bench-m1-w5", "Bench Press", "Compound exercise for chest, shoulders, and triceps", 3, 8, 35, "workout-m1-w5"));

            // Month 2
            exercises.Add(CreateExercise("bench-m2-w1", "Bench Press", "Compound exercise for chest, shoulders, and triceps", 3, 10, 35, "workout-m2-w1"));
            exercises.Add(CreateExercise("bench-m2-w2", "Bench Press", "Compound exercise for chest, shoulders, and triceps", 3, 12, 35, "workout-m2-w2"));
            exercises.Add(CreateExercise("bench-m2-w4", "Bench Press", "Compound exercise for chest, shoulders, and triceps", 3, 8, 40, "workout-m2-w4"));
            exercises.Add(CreateExercise("bench-m2-w5", "Bench Press", "Compound exercise for chest, shoulders, and triceps", 3, 10, 40, "workout-m2-w5"));

            // Month 3
            exercises.Add(CreateExercise("bench-m3-w1", "Bench Press", "Compound exercise for chest, shoulders, and triceps", 3, 12, 40, "workout-m3-w1"));
            exercises.Add(CreateExercise("bench-m3-w2", "Bench Press", "Compound exercise for chest, shoulders, and triceps", 3, 8, 45, "workout-m3-w2"));
            exercises.Add(CreateExercise("bench-m3-w4", "Bench Press", "Compound exercise for chest, shoulders, and triceps", 3, 10, 45, "workout-m3-w4"));
            exercises.Add(CreateExercise("bench-m3-w5", "Bench Press", "Compound exercise for chest, shoulders, and triceps", 3, 10, 50, "workout-m3-w5"));

            // Current week - keep the existing ID from the current seed data
            exercises.Add(CreateExercise("2f3a4b5c-6d7e-8f9a-0b1c-2d3e4f5a6b7c", "Bench Press", "Compound exercise for chest, shoulders, and triceps", 3, 10, 50, "1a2b3c4d-5e6f-7a8b-9c0d-1e2f3a4b5c6d"));

            // DEADLIFT PROGRESSION
            // Month 1
            exercises.Add(CreateExercise("deadlift-m1-w1", "Deadlifts", "Full body compound exercise emphasizing posterior chain", 3, 6, 50, "workout-m1-w1"));
            exercises.Add(CreateExercise("deadlift-m1-w3", "Deadlifts", "Full body compound exercise emphasizing posterior chain", 3, 8, 50, "workout-m1-w3"));
            exercises.Add(CreateExercise("deadlift-m1-w4", "Deadlifts", "Full body compound exercise emphasizing posterior chain", 4, 6, 55, "workout-m1-w4"));
            exercises.Add(CreateExercise("deadlift-m1-w6", "Deadlifts", "Full body compound exercise emphasizing posterior chain", 4, 8, 55, "workout-m1-w6"));

            // Month 2
            exercises.Add(CreateExercise("deadlift-m2-w1", "Deadlifts", "Full body compound exercise emphasizing posterior chain", 4, 6, 60, "workout-m2-w1"));
            exercises.Add(CreateExercise("deadlift-m2-w3", "Deadlifts", "Full body compound exercise emphasizing posterior chain", 4, 8, 60, "workout-m2-w3"));
            exercises.Add(CreateExercise("deadlift-m2-w4", "Deadlifts", "Full body compound exercise emphasizing posterior chain", 4, 6, 70, "workout-m2-w4"));
            exercises.Add(CreateExercise("deadlift-m2-w6", "Deadlifts", "Full body compound exercise emphasizing posterior chain", 4, 8, 70, "workout-m2-w6"));

            // Month 3
            exercises.Add(CreateExercise("deadlift-m3-w1", "Deadlifts", "Full body compound exercise emphasizing posterior chain", 4, 6, 75, "workout-m3-w1"));
            exercises.Add(CreateExercise("deadlift-m3-w3", "Deadlifts", "Full body compound exercise emphasizing posterior chain", 4, 8, 75, "workout-m3-w3"));
            exercises.Add(CreateExercise("deadlift-m3-w4", "Deadlifts", "Full body compound exercise emphasizing posterior chain", 4, 6, 80, "workout-m3-w4"));
            exercises.Add(CreateExercise("deadlift-m3-w6", "Deadlifts", "Full body compound exercise emphasizing posterior chain", 4, 8, 80, "workout-m3-w6"));

            // Current week - keep the existing ID from the current seed data
            exercises.Add(CreateExercise("3a4b5c6d-7e8f-9a0b-1c2d-3e4f5a6b7c8d", "Deadlifts", "Full body compound exercise emphasizing posterior chain", 4, 8, 80, "1a2b3c4d-5e6f-7a8b-9c0d-1e2f3a4b5c6d"));

            // PULL-UPS PROGRESSION
            // Month 1
            exercises.Add(CreateExercise("pullup-m1-w1", "Pull-ups", "Bodyweight exercise targeting back and biceps", 2, 5, 0, "workout-m1-w1"));
            exercises.Add(CreateExercise("pullup-m1-w2", "Pull-ups", "Bodyweight exercise targeting back and biceps", 2, 6, 0, "workout-m1-w2"));
            exercises.Add(CreateExercise("pullup-m1-w4", "Pull-ups", "Bodyweight exercise targeting back and biceps", 3, 5, 0, "workout-m1-w4"));
            exercises.Add(CreateExercise("pullup-m1-w5", "Pull-ups", "Bodyweight exercise targeting back and biceps", 3, 6, 0, "workout-m1-w5"));

            // Month 2
            exercises.Add(CreateExercise("pullup-m2-w1", "Pull-ups", "Bodyweight exercise targeting back and biceps", 3, 6, 0, "workout-m2-w1"));
            exercises.Add(CreateExercise("pullup-m2-w2", "Pull-ups", "Bodyweight exercise targeting back and biceps", 3, 7, 0, "workout-m2-w2"));
            exercises.Add(CreateExercise("pullup-m2-w4", "Pull-ups", "Bodyweight exercise targeting back and biceps", 3, 7, 0, "workout-m2-w4"));
            exercises.Add(CreateExercise("pullup-m2-w5", "Pull-ups", "Bodyweight exercise targeting back and biceps", 3, 8, 0, "workout-m2-w5"));

            // Month 3
            exercises.Add(CreateExercise("pullup-m3-w1", "Pull-ups", "Bodyweight exercise targeting back and biceps", 3, 8, 0, "workout-m3-w1"));
            exercises.Add(CreateExercise("pullup-m3-w2", "Pull-ups", "Bodyweight exercise targeting back and biceps", 3, 8, 0, "workout-m3-w2"));
            exercises.Add(CreateExercise("pullup-m3-w4", "Pull-ups", "Bodyweight exercise targeting back and biceps", 3, 8, 0, "workout-m3-w4"));
            exercises.Add(CreateExercise("pullup-m3-w5", "Pull-ups", "Bodyweight exercise targeting back and biceps", 3, 8, 0, "workout-m3-w5"));

            // Current week - keep the existing ID from the current seed data
            exercises.Add(CreateExercise("4b5c6d7e-8f9a-0b1c-2d3e-4f5a6b7c8d9e", "Pull-ups", "Bodyweight exercise targeting back and biceps", 3, 8, 0, "2b3c4d5e-6f7a-8b9c-0d1e-2f3a4b5c6d7e"));

            // SHOULDER PRESS PROGRESSION
            // Month 1
            exercises.Add(CreateExercise("shoulder-m1-w1", "Shoulder Press", "Overhead press targeting deltoids and triceps", 3, 8, 20, "workout-m1-w1"));
            exercises.Add(CreateExercise("shoulder-m1-w2", "Shoulder Press", "Overhead press targeting deltoids and triceps", 3, 10, 20, "workout-m1-w2"));
            exercises.Add(CreateExercise("shoulder-m1-w4", "Shoulder Press", "Overhead press targeting deltoids and triceps", 3, 12, 20, "workout-m1-w4"));
            exercises.Add(CreateExercise("shoulder-m1-w5", "Shoulder Press", "Overhead press targeting deltoids and triceps", 3, 8, 25, "workout-m1-w5"));

            // Month 2
            exercises.Add(CreateExercise("shoulder-m2-w1", "Shoulder Press", "Overhead press targeting deltoids and triceps", 3, 10, 25, "workout-m2-w1"));
            exercises.Add(CreateExercise("shoulder-m2-w2", "Shoulder Press", "Overhead press targeting deltoids and triceps", 3, 12, 25, "workout-m2-w2"));
            exercises.Add(CreateExercise("shoulder-m2-w4", "Shoulder Press", "Overhead press targeting deltoids and triceps", 3, 8, 30, "workout-m2-w4"));
            exercises.Add(CreateExercise("shoulder-m2-w5", "Shoulder Press", "Overhead press targeting deltoids and triceps", 3, 10, 30, "workout-m2-w5"));

            // Month 3
            exercises.Add(CreateExercise("shoulder-m3-w1", "Shoulder Press", "Overhead press targeting deltoids and triceps", 3, 12, 30, "workout-m3-w1"));
            exercises.Add(CreateExercise("shoulder-m3-w2", "Shoulder Press", "Overhead press targeting deltoids and triceps", 3, 10, 35, "workout-m3-w2"));
            exercises.Add(CreateExercise("shoulder-m3-w4", "Shoulder Press", "Overhead press targeting deltoids and triceps", 3, 12, 35, "workout-m3-w4"));
            exercises.Add(CreateExercise("shoulder-m3-w5", "Shoulder Press", "Overhead press targeting deltoids and triceps", 3, 12, 40, "workout-m3-w5"));

            // Current week - keep the existing ID from the current seed data
            exercises.Add(CreateExercise("5c6d7e8f-9a0b-1c2d-3e4f-5a6b7c8d9e0f", "Shoulder Press", "Overhead press targeting deltoids and triceps", 3, 12, 40, "2b3c4d5e-6f7a-8b9c-0d1e-2f3a4b5c6d7e"));

            // BICEP CURLS PROGRESSION
            // Month 1
            exercises.Add(CreateExercise("bicep-m1-w1", "Bicep Curls", "Isolation exercise for biceps", 3, 10, 8, "workout-m1-w1"));
            exercises.Add(CreateExercise("bicep-m1-w2", "Bicep Curls", "Isolation exercise for biceps", 3, 12, 8, "workout-m1-w2"));
            exercises.Add(CreateExercise("bicep-m1-w4", "Bicep Curls", "Isolation exercise for biceps", 3, 15, 8, "workout-m1-w4"));
            exercises.Add(CreateExercise("bicep-m1-w5", "Bicep Curls", "Isolation exercise for biceps", 3, 10, 10, "workout-m1-w5"));

            // Month 2
            exercises.Add(CreateExercise("bicep-m2-w1", "Bicep Curls", "Isolation exercise for biceps", 3, 12, 10, "workout-m2-w1"));
            exercises.Add(CreateExercise("bicep-m2-w2", "Bicep Curls", "Isolation exercise for biceps", 3, 15, 10, "workout-m2-w2"));
            exercises.Add(CreateExercise("bicep-m2-w4", "Bicep Curls", "Isolation exercise for biceps", 3, 12, 12, "workout-m2-w4"));
            exercises.Add(CreateExercise("bicep-m2-w5", "Bicep Curls", "Isolation exercise for biceps", 3, 15, 12, "workout-m2-w5"));

            // Month 3
            exercises.Add(CreateExercise("bicep-m3-w1", "Bicep Curls", "Isolation exercise for biceps", 3, 12, 14, "workout-m3-w1"));
            exercises.Add(CreateExercise("bicep-m3-w2", "Bicep Curls", "Isolation exercise for biceps", 3, 15, 14, "workout-m3-w2"));
            exercises.Add(CreateExercise("bicep-m3-w4", "Bicep Curls", "Isolation exercise for biceps", 3, 12, 15, "workout-m3-w4"));
            exercises.Add(CreateExercise("bicep-m3-w5", "Bicep Curls", "Isolation exercise for biceps", 3, 15, 15, "workout-m3-w5"));

            // Current week - keep the existing ID from the current seed data
            exercises.Add(CreateExercise("6d7e8f9a-0b1c-2d3e-4f5a-6b7c8d9e0f1a", "Bicep Curls", "Isolation exercise for biceps", 3, 15, 15, "2b3c4d5e-6f7a-8b9c-0d1e-2f3a4b5c6d7e"));

            // LEG PRESS PROGRESSION
            // Month 1
            exercises.Add(CreateExercise("legpress-m1-w1", "Leg Press", "Machine-based compound leg exercise", 3, 10, 60, "workout-m1-w1"));
            exercises.Add(CreateExercise("legpress-m1-w3", "Leg Press", "Machine-based compound leg exercise", 3, 12, 60, "workout-m1-w3"));
            exercises.Add(CreateExercise("legpress-m1-w4", "Leg Press", "Machine-based compound leg exercise", 4, 10, 70, "workout-m1-w4"));
            exercises.Add(CreateExercise("legpress-m1-w6", "Leg Press", "Machine-based compound leg exercise", 4, 12, 70, "workout-m1-w6"));

            // Month 2
            exercises.Add(CreateExercise("legpress-m2-w1", "Leg Press", "Machine-based compound leg exercise", 4, 10, 80, "workout-m2-w1"));
            exercises.Add(CreateExercise("legpress-m2-w3", "Leg Press", "Machine-based compound leg exercise", 4, 12, 80, "workout-m2-w3"));
            exercises.Add(CreateExercise("legpress-m2-w4", "Leg Press", "Machine-based compound leg exercise", 4, 10, 90, "workout-m2-w4"));
            exercises.Add(CreateExercise("legpress-m2-w6", "Leg Press", "Machine-based compound leg exercise", 4, 12, 90, "workout-m2-w6"));

            // Month 3
            exercises.Add(CreateExercise("legpress-m3-w1", "Leg Press", "Machine-based compound leg exercise", 4, 10, 100, "workout-m3-w1"));
            exercises.Add(CreateExercise("legpress-m3-w3", "Leg Press", "Machine-based compound leg exercise", 4, 12, 100, "workout-m3-w3"));
            exercises.Add(CreateExercise("legpress-m3-w4", "Leg Press", "Machine-based compound leg exercise", 4, 10, 100, "workout-m3-w4"));
            exercises.Add(CreateExercise("legpress-m3-w6", "Leg Press", "Machine-based compound leg exercise", 4, 12, 100, "workout-m3-w6"));

            // Current week - keep the existing ID from the current seed data
            exercises.Add(CreateExercise("7e8f9a0b-1c2d-3e4f-5a6b-7c8d9e0f1a2b", "Leg Press", "Machine-based compound leg exercise", 4, 12, 100, "3c4d5e6f-7a8b-9c0d-1e2f-3a4b5c6d7e8f"));

            // ROMANIAN DEADLIFT PROGRESSION
            // Month 1
            exercises.Add(CreateExercise("rdl-m1-w1", "Romanian Deadlifts", "Targets hamstrings and lower back", 3, 8, 40, "workout-m1-w1"));
            exercises.Add(CreateExercise("rdl-m1-w3", "Romanian Deadlifts", "Targets hamstrings and lower back", 3, 10, 40, "workout-m1-w3"));
            exercises.Add(CreateExercise("rdl-m1-w4", "Romanian Deadlifts", "Targets hamstrings and lower back", 3, 8, 45, "workout-m1-w4"));
            exercises.Add(CreateExercise("rdl-m1-w6", "Romanian Deadlifts", "Targets hamstrings and lower back", 3, 10, 45, "workout-m1-w6"));

            // Month 2
            exercises.Add(CreateExercise("rdl-m2-w1", "Romanian Deadlifts", "Targets hamstrings and lower back", 3, 8, 50, "workout-m2-w1"));
            exercises.Add(CreateExercise("rdl-m2-w3", "Romanian Deadlifts", "Targets hamstrings and lower back", 3, 10, 50, "workout-m2-w3"));
            exercises.Add(CreateExercise("rdl-m2-w4", "Romanian Deadlifts", "Targets hamstrings and lower back", 3, 8, 60, "workout-m2-w4"));
            exercises.Add(CreateExercise("rdl-m2-w6", "Romanian Deadlifts", "Targets hamstrings and lower back", 3, 10, 60, "workout-m2-w6"));

            // Month 3
            exercises.Add(CreateExercise("rdl-m3-w1", "Romanian Deadlifts", "Targets hamstrings and lower back", 3, 8, 65, "workout-m3-w1"));
            exercises.Add(CreateExercise("rdl-m3-w3", "Romanian Deadlifts", "Targets hamstrings and lower back", 3, 10, 65, "workout-m3-w3"));
            exercises.Add(CreateExercise("rdl-m3-w4", "Romanian Deadlifts", "Targets hamstrings and lower back", 3, 8, 70, "workout-m3-w4"));
            exercises.Add(CreateExercise("rdl-m3-w6", "Romanian Deadlifts", "Targets hamstrings and lower back", 3, 10, 70, "workout-m3-w6"));

            // Current week - keep the existing ID from the current seed data
            exercises.Add(CreateExercise("8f9a0b1c-2d3e-4f5a-6b7c-8d9e0f1a2b3c", "Romanian Deadlifts", "Targets hamstrings and lower back", 3, 10, 70, "3c4d5e6f-7a8b-9c0d-1e2f-3a4b5c6d7e8f"));

            // CALF RAISES PROGRESSION
            // Month 1
            exercises.Add(CreateExercise("calf-m1-w1", "Calf Raises", "Isolation exercise for calf muscles", 3, 15, 10, "workout-m1-w1"));
            exercises.Add(CreateExercise("calf-m1-w3", "Calf Raises", "Isolation exercise for calf muscles", 3, 18, 10, "workout-m1-w3"));
            exercises.Add(CreateExercise("calf-m1-w4", "Calf Raises", "Isolation exercise for calf muscles", 3, 20, 10, "workout-m1-w4"));
            exercises.Add(CreateExercise("calf-m1-w6", "Calf Raises", "Isolation exercise for calf muscles", 3, 15, 15, "workout-m1-w6"));

            // Month 2
            exercises.Add(CreateExercise("calf-m2-w1", "Calf Raises", "Isolation exercise for calf muscles", 3, 18, 15, "workout-m2-w1"));
            exercises.Add(CreateExercise("calf-m2-w3", "Calf Raises", "Isolation exercise for calf muscles", 3, 20, 15, "workout-m2-w3"));
            exercises.Add(CreateExercise("calf-m2-w4", "Calf Raises", "Isolation exercise for calf muscles", 4, 15, 20, "workout-m2-w4"));
            exercises.Add(CreateExercise("calf-m2-w6", "Calf Raises", "Isolation exercise for calf muscles", 4, 18, 20, "workout-m2-w6"));

            // Month 3
            exercises.Add(CreateExercise("calf-m3-w1", "Calf Raises", "Isolation exercise for calf muscles", 4, 20, 20, "workout-m3-w1"));
            exercises.Add(CreateExercise("calf-m3-w3", "Calf Raises", "Isolation exercise for calf muscles", 4, 18, 25, "workout-m3-w3"));
            exercises.Add(CreateExercise("calf-m3-w4", "Calf Raises", "Isolation exercise for calf muscles", 4, 20, 25, "workout-m3-w4"));
            exercises.Add(CreateExercise("calf-m3-w6", "Calf Raises", "Isolation exercise for calf muscles", 4, 20, 30, "workout-m3-w6"));

            // Current week - keep the existing ID from the current seed data
            exercises.Add(CreateExercise("9a0b1c2d-3e4f-5a6b-7c8d-9e0f1a2b3c4d", "Calf Raises", "Isolation exercise for calf muscles", 4, 20, 30, "3c4d5e6f-7a8b-9c0d-1e2f-3a4b5c6d7e8f"));

            // Add workouts and exercises to model builder
            modelBuilder.Entity<Workout>().HasData(workouts);
            modelBuilder.Entity<Exercise>().HasData(exercises);
        }
    }
}
