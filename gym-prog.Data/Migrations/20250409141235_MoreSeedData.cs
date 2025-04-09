using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace gym_prog.Data.Migrations
{
    /// <inheritdoc />
    public partial class MoreSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: "1a2b3c4d-5e6f-7a8b-9c0d-1e2f3a4b5c6d",
                column: "Date",
                value: new DateTime(2025, 4, 6, 17, 12, 35, 246, DateTimeKind.Local).AddTicks(6159));

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: "2b3c4d5e-6f7a-8b9c-0d1e-2f3a4b5c6d7e",
                column: "Date",
                value: new DateTime(2025, 4, 8, 17, 12, 35, 246, DateTimeKind.Local).AddTicks(6159));

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: "3c4d5e6f-7a8b-9c0d-1e2f-3a4b5c6d7e8f",
                column: "Date",
                value: new DateTime(2025, 4, 9, 17, 12, 35, 246, DateTimeKind.Local).AddTicks(6159));

            migrationBuilder.InsertData(
                table: "Workouts",
                columns: new[] { "Id", "Date", "Description", "Name" },
                values: new object[,]
                {
                    { "workout-m1-w1", new DateTime(2025, 1, 15, 17, 12, 35, 246, DateTimeKind.Local).AddTicks(6159), "A comprehensive workout that targets all major muscle groups", "Full Body Workout" },
                    { "workout-m1-w2", new DateTime(2025, 1, 19, 17, 12, 35, 246, DateTimeKind.Local).AddTicks(6159), "Targets chest, shoulders, back, and arms", "Upper Body Focus" },
                    { "workout-m1-w3", new DateTime(2025, 1, 22, 17, 12, 35, 246, DateTimeKind.Local).AddTicks(6159), "Focuses on quads, hamstrings, calves, and glutes", "Lower Body Strength" },
                    { "workout-m1-w4", new DateTime(2025, 1, 29, 17, 12, 35, 246, DateTimeKind.Local).AddTicks(6159), "A comprehensive workout that targets all major muscle groups", "Full Body Workout" },
                    { "workout-m1-w5", new DateTime(2025, 2, 2, 17, 12, 35, 246, DateTimeKind.Local).AddTicks(6159), "Targets chest, shoulders, back, and arms", "Upper Body Focus" },
                    { "workout-m1-w6", new DateTime(2025, 2, 5, 17, 12, 35, 246, DateTimeKind.Local).AddTicks(6159), "Focuses on quads, hamstrings, calves, and glutes", "Lower Body Strength" },
                    { "workout-m2-w1", new DateTime(2025, 2, 12, 17, 12, 35, 246, DateTimeKind.Local).AddTicks(6159), "A comprehensive workout that targets all major muscle groups", "Full Body Workout" },
                    { "workout-m2-w2", new DateTime(2025, 2, 16, 17, 12, 35, 246, DateTimeKind.Local).AddTicks(6159), "Targets chest, shoulders, back, and arms", "Upper Body Focus" },
                    { "workout-m2-w3", new DateTime(2025, 2, 19, 17, 12, 35, 246, DateTimeKind.Local).AddTicks(6159), "Focuses on quads, hamstrings, calves, and glutes", "Lower Body Strength" },
                    { "workout-m2-w4", new DateTime(2025, 2, 26, 17, 12, 35, 246, DateTimeKind.Local).AddTicks(6159), "A comprehensive workout that targets all major muscle groups", "Full Body Workout" },
                    { "workout-m2-w5", new DateTime(2025, 3, 2, 17, 12, 35, 246, DateTimeKind.Local).AddTicks(6159), "Targets chest, shoulders, back, and arms", "Upper Body Focus" },
                    { "workout-m2-w6", new DateTime(2025, 3, 5, 17, 12, 35, 246, DateTimeKind.Local).AddTicks(6159), "Focuses on quads, hamstrings, calves, and glutes", "Lower Body Strength" },
                    { "workout-m3-w1", new DateTime(2025, 3, 12, 17, 12, 35, 246, DateTimeKind.Local).AddTicks(6159), "A comprehensive workout that targets all major muscle groups", "Full Body Workout" },
                    { "workout-m3-w2", new DateTime(2025, 3, 16, 17, 12, 35, 246, DateTimeKind.Local).AddTicks(6159), "Targets chest, shoulders, back, and arms", "Upper Body Focus" },
                    { "workout-m3-w3", new DateTime(2025, 3, 19, 17, 12, 35, 246, DateTimeKind.Local).AddTicks(6159), "Focuses on quads, hamstrings, calves, and glutes", "Lower Body Strength" },
                    { "workout-m3-w4", new DateTime(2025, 3, 26, 17, 12, 35, 246, DateTimeKind.Local).AddTicks(6159), "A comprehensive workout that targets all major muscle groups", "Full Body Workout" },
                    { "workout-m3-w5", new DateTime(2025, 3, 30, 17, 12, 35, 246, DateTimeKind.Local).AddTicks(6159), "Targets chest, shoulders, back, and arms", "Upper Body Focus" },
                    { "workout-m3-w6", new DateTime(2025, 4, 2, 17, 12, 35, 246, DateTimeKind.Local).AddTicks(6159), "Focuses on quads, hamstrings, calves, and glutes", "Lower Body Strength" }
                });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "Description", "Name", "Reps", "Sets", "Weight", "WorkoutId" },
                values: new object[,]
                {
                    { "bench-m1-w1", "Compound exercise for chest, shoulders, and triceps", "Bench Press", 8, 3, 30, "workout-m1-w1" },
                    { "bench-m1-w2", "Compound exercise for chest, shoulders, and triceps", "Bench Press", 10, 3, 30, "workout-m1-w2" },
                    { "bench-m1-w4", "Compound exercise for chest, shoulders, and triceps", "Bench Press", 12, 3, 30, "workout-m1-w4" },
                    { "bench-m1-w5", "Compound exercise for chest, shoulders, and triceps", "Bench Press", 8, 3, 35, "workout-m1-w5" },
                    { "bench-m2-w1", "Compound exercise for chest, shoulders, and triceps", "Bench Press", 10, 3, 35, "workout-m2-w1" },
                    { "bench-m2-w2", "Compound exercise for chest, shoulders, and triceps", "Bench Press", 12, 3, 35, "workout-m2-w2" },
                    { "bench-m2-w4", "Compound exercise for chest, shoulders, and triceps", "Bench Press", 8, 3, 40, "workout-m2-w4" },
                    { "bench-m2-w5", "Compound exercise for chest, shoulders, and triceps", "Bench Press", 10, 3, 40, "workout-m2-w5" },
                    { "bench-m3-w1", "Compound exercise for chest, shoulders, and triceps", "Bench Press", 12, 3, 40, "workout-m3-w1" },
                    { "bench-m3-w2", "Compound exercise for chest, shoulders, and triceps", "Bench Press", 8, 3, 45, "workout-m3-w2" },
                    { "bench-m3-w4", "Compound exercise for chest, shoulders, and triceps", "Bench Press", 10, 3, 45, "workout-m3-w4" },
                    { "bench-m3-w5", "Compound exercise for chest, shoulders, and triceps", "Bench Press", 10, 3, 50, "workout-m3-w5" },
                    { "bicep-m1-w1", "Isolation exercise for biceps", "Bicep Curls", 10, 3, 8, "workout-m1-w1" },
                    { "bicep-m1-w2", "Isolation exercise for biceps", "Bicep Curls", 12, 3, 8, "workout-m1-w2" },
                    { "bicep-m1-w4", "Isolation exercise for biceps", "Bicep Curls", 15, 3, 8, "workout-m1-w4" },
                    { "bicep-m1-w5", "Isolation exercise for biceps", "Bicep Curls", 10, 3, 10, "workout-m1-w5" },
                    { "bicep-m2-w1", "Isolation exercise for biceps", "Bicep Curls", 12, 3, 10, "workout-m2-w1" },
                    { "bicep-m2-w2", "Isolation exercise for biceps", "Bicep Curls", 15, 3, 10, "workout-m2-w2" },
                    { "bicep-m2-w4", "Isolation exercise for biceps", "Bicep Curls", 12, 3, 12, "workout-m2-w4" },
                    { "bicep-m2-w5", "Isolation exercise for biceps", "Bicep Curls", 15, 3, 12, "workout-m2-w5" },
                    { "bicep-m3-w1", "Isolation exercise for biceps", "Bicep Curls", 12, 3, 14, "workout-m3-w1" },
                    { "bicep-m3-w2", "Isolation exercise for biceps", "Bicep Curls", 15, 3, 14, "workout-m3-w2" },
                    { "bicep-m3-w4", "Isolation exercise for biceps", "Bicep Curls", 12, 3, 15, "workout-m3-w4" },
                    { "bicep-m3-w5", "Isolation exercise for biceps", "Bicep Curls", 15, 3, 15, "workout-m3-w5" },
                    { "calf-m1-w1", "Isolation exercise for calf muscles", "Calf Raises", 15, 3, 10, "workout-m1-w1" },
                    { "calf-m1-w3", "Isolation exercise for calf muscles", "Calf Raises", 18, 3, 10, "workout-m1-w3" },
                    { "calf-m1-w4", "Isolation exercise for calf muscles", "Calf Raises", 20, 3, 10, "workout-m1-w4" },
                    { "calf-m1-w6", "Isolation exercise for calf muscles", "Calf Raises", 15, 3, 15, "workout-m1-w6" },
                    { "calf-m2-w1", "Isolation exercise for calf muscles", "Calf Raises", 18, 3, 15, "workout-m2-w1" },
                    { "calf-m2-w3", "Isolation exercise for calf muscles", "Calf Raises", 20, 3, 15, "workout-m2-w3" },
                    { "calf-m2-w4", "Isolation exercise for calf muscles", "Calf Raises", 15, 4, 20, "workout-m2-w4" },
                    { "calf-m2-w6", "Isolation exercise for calf muscles", "Calf Raises", 18, 4, 20, "workout-m2-w6" },
                    { "calf-m3-w1", "Isolation exercise for calf muscles", "Calf Raises", 20, 4, 20, "workout-m3-w1" },
                    { "calf-m3-w3", "Isolation exercise for calf muscles", "Calf Raises", 18, 4, 25, "workout-m3-w3" },
                    { "calf-m3-w4", "Isolation exercise for calf muscles", "Calf Raises", 20, 4, 25, "workout-m3-w4" },
                    { "calf-m3-w6", "Isolation exercise for calf muscles", "Calf Raises", 20, 4, 30, "workout-m3-w6" },
                    { "deadlift-m1-w1", "Full body compound exercise emphasizing posterior chain", "Deadlifts", 6, 3, 50, "workout-m1-w1" },
                    { "deadlift-m1-w3", "Full body compound exercise emphasizing posterior chain", "Deadlifts", 8, 3, 50, "workout-m1-w3" },
                    { "deadlift-m1-w4", "Full body compound exercise emphasizing posterior chain", "Deadlifts", 6, 4, 55, "workout-m1-w4" },
                    { "deadlift-m1-w6", "Full body compound exercise emphasizing posterior chain", "Deadlifts", 8, 4, 55, "workout-m1-w6" },
                    { "deadlift-m2-w1", "Full body compound exercise emphasizing posterior chain", "Deadlifts", 6, 4, 60, "workout-m2-w1" },
                    { "deadlift-m2-w3", "Full body compound exercise emphasizing posterior chain", "Deadlifts", 8, 4, 60, "workout-m2-w3" },
                    { "deadlift-m2-w4", "Full body compound exercise emphasizing posterior chain", "Deadlifts", 6, 4, 70, "workout-m2-w4" },
                    { "deadlift-m2-w6", "Full body compound exercise emphasizing posterior chain", "Deadlifts", 8, 4, 70, "workout-m2-w6" },
                    { "deadlift-m3-w1", "Full body compound exercise emphasizing posterior chain", "Deadlifts", 6, 4, 75, "workout-m3-w1" },
                    { "deadlift-m3-w3", "Full body compound exercise emphasizing posterior chain", "Deadlifts", 8, 4, 75, "workout-m3-w3" },
                    { "deadlift-m3-w4", "Full body compound exercise emphasizing posterior chain", "Deadlifts", 6, 4, 80, "workout-m3-w4" },
                    { "deadlift-m3-w6", "Full body compound exercise emphasizing posterior chain", "Deadlifts", 8, 4, 80, "workout-m3-w6" },
                    { "legpress-m1-w1", "Machine-based compound leg exercise", "Leg Press", 10, 3, 60, "workout-m1-w1" },
                    { "legpress-m1-w3", "Machine-based compound leg exercise", "Leg Press", 12, 3, 60, "workout-m1-w3" },
                    { "legpress-m1-w4", "Machine-based compound leg exercise", "Leg Press", 10, 4, 70, "workout-m1-w4" },
                    { "legpress-m1-w6", "Machine-based compound leg exercise", "Leg Press", 12, 4, 70, "workout-m1-w6" },
                    { "legpress-m2-w1", "Machine-based compound leg exercise", "Leg Press", 10, 4, 80, "workout-m2-w1" },
                    { "legpress-m2-w3", "Machine-based compound leg exercise", "Leg Press", 12, 4, 80, "workout-m2-w3" },
                    { "legpress-m2-w4", "Machine-based compound leg exercise", "Leg Press", 10, 4, 90, "workout-m2-w4" },
                    { "legpress-m2-w6", "Machine-based compound leg exercise", "Leg Press", 12, 4, 90, "workout-m2-w6" },
                    { "legpress-m3-w1", "Machine-based compound leg exercise", "Leg Press", 10, 4, 100, "workout-m3-w1" },
                    { "legpress-m3-w3", "Machine-based compound leg exercise", "Leg Press", 12, 4, 100, "workout-m3-w3" },
                    { "legpress-m3-w4", "Machine-based compound leg exercise", "Leg Press", 10, 4, 100, "workout-m3-w4" },
                    { "legpress-m3-w6", "Machine-based compound leg exercise", "Leg Press", 12, 4, 100, "workout-m3-w6" },
                    { "pullup-m1-w1", "Bodyweight exercise targeting back and biceps", "Pull-ups", 5, 2, 0, "workout-m1-w1" },
                    { "pullup-m1-w2", "Bodyweight exercise targeting back and biceps", "Pull-ups", 6, 2, 0, "workout-m1-w2" },
                    { "pullup-m1-w4", "Bodyweight exercise targeting back and biceps", "Pull-ups", 5, 3, 0, "workout-m1-w4" },
                    { "pullup-m1-w5", "Bodyweight exercise targeting back and biceps", "Pull-ups", 6, 3, 0, "workout-m1-w5" },
                    { "pullup-m2-w1", "Bodyweight exercise targeting back and biceps", "Pull-ups", 6, 3, 0, "workout-m2-w1" },
                    { "pullup-m2-w2", "Bodyweight exercise targeting back and biceps", "Pull-ups", 7, 3, 0, "workout-m2-w2" },
                    { "pullup-m2-w4", "Bodyweight exercise targeting back and biceps", "Pull-ups", 7, 3, 0, "workout-m2-w4" },
                    { "pullup-m2-w5", "Bodyweight exercise targeting back and biceps", "Pull-ups", 8, 3, 0, "workout-m2-w5" },
                    { "pullup-m3-w1", "Bodyweight exercise targeting back and biceps", "Pull-ups", 8, 3, 0, "workout-m3-w1" },
                    { "pullup-m3-w2", "Bodyweight exercise targeting back and biceps", "Pull-ups", 8, 3, 0, "workout-m3-w2" },
                    { "pullup-m3-w4", "Bodyweight exercise targeting back and biceps", "Pull-ups", 8, 3, 0, "workout-m3-w4" },
                    { "pullup-m3-w5", "Bodyweight exercise targeting back and biceps", "Pull-ups", 8, 3, 0, "workout-m3-w5" },
                    { "rdl-m1-w1", "Targets hamstrings and lower back", "Romanian Deadlifts", 8, 3, 40, "workout-m1-w1" },
                    { "rdl-m1-w3", "Targets hamstrings and lower back", "Romanian Deadlifts", 10, 3, 40, "workout-m1-w3" },
                    { "rdl-m1-w4", "Targets hamstrings and lower back", "Romanian Deadlifts", 8, 3, 45, "workout-m1-w4" },
                    { "rdl-m1-w6", "Targets hamstrings and lower back", "Romanian Deadlifts", 10, 3, 45, "workout-m1-w6" },
                    { "rdl-m2-w1", "Targets hamstrings and lower back", "Romanian Deadlifts", 8, 3, 50, "workout-m2-w1" },
                    { "rdl-m2-w3", "Targets hamstrings and lower back", "Romanian Deadlifts", 10, 3, 50, "workout-m2-w3" },
                    { "rdl-m2-w4", "Targets hamstrings and lower back", "Romanian Deadlifts", 8, 3, 60, "workout-m2-w4" },
                    { "rdl-m2-w6", "Targets hamstrings and lower back", "Romanian Deadlifts", 10, 3, 60, "workout-m2-w6" },
                    { "rdl-m3-w1", "Targets hamstrings and lower back", "Romanian Deadlifts", 8, 3, 65, "workout-m3-w1" },
                    { "rdl-m3-w3", "Targets hamstrings and lower back", "Romanian Deadlifts", 10, 3, 65, "workout-m3-w3" },
                    { "rdl-m3-w4", "Targets hamstrings and lower back", "Romanian Deadlifts", 8, 3, 70, "workout-m3-w4" },
                    { "rdl-m3-w6", "Targets hamstrings and lower back", "Romanian Deadlifts", 10, 3, 70, "workout-m3-w6" },
                    { "shoulder-m1-w1", "Overhead press targeting deltoids and triceps", "Shoulder Press", 8, 3, 20, "workout-m1-w1" },
                    { "shoulder-m1-w2", "Overhead press targeting deltoids and triceps", "Shoulder Press", 10, 3, 20, "workout-m1-w2" },
                    { "shoulder-m1-w4", "Overhead press targeting deltoids and triceps", "Shoulder Press", 12, 3, 20, "workout-m1-w4" },
                    { "shoulder-m1-w5", "Overhead press targeting deltoids and triceps", "Shoulder Press", 8, 3, 25, "workout-m1-w5" },
                    { "shoulder-m2-w1", "Overhead press targeting deltoids and triceps", "Shoulder Press", 10, 3, 25, "workout-m2-w1" },
                    { "shoulder-m2-w2", "Overhead press targeting deltoids and triceps", "Shoulder Press", 12, 3, 25, "workout-m2-w2" },
                    { "shoulder-m2-w4", "Overhead press targeting deltoids and triceps", "Shoulder Press", 8, 3, 30, "workout-m2-w4" },
                    { "shoulder-m2-w5", "Overhead press targeting deltoids and triceps", "Shoulder Press", 10, 3, 30, "workout-m2-w5" },
                    { "shoulder-m3-w1", "Overhead press targeting deltoids and triceps", "Shoulder Press", 12, 3, 30, "workout-m3-w1" },
                    { "shoulder-m3-w2", "Overhead press targeting deltoids and triceps", "Shoulder Press", 10, 3, 35, "workout-m3-w2" },
                    { "shoulder-m3-w4", "Overhead press targeting deltoids and triceps", "Shoulder Press", 12, 3, 35, "workout-m3-w4" },
                    { "shoulder-m3-w5", "Overhead press targeting deltoids and triceps", "Shoulder Press", 12, 3, 40, "workout-m3-w5" },
                    { "squat-m1-w1", "Compound exercise targeting quads, hamstrings, and glutes", "Squats", 8, 3, 40, "workout-m1-w1" },
                    { "squat-m1-w3", "Compound exercise targeting quads, hamstrings, and glutes", "Squats", 10, 3, 40, "workout-m1-w3" },
                    { "squat-m1-w4", "Compound exercise targeting quads, hamstrings, and glutes", "Squats", 12, 3, 40, "workout-m1-w4" },
                    { "squat-m1-w6", "Compound exercise targeting quads, hamstrings, and glutes", "Squats", 8, 4, 45, "workout-m1-w6" },
                    { "squat-m2-w1", "Compound exercise targeting quads, hamstrings, and glutes", "Squats", 10, 4, 45, "workout-m2-w1" },
                    { "squat-m2-w3", "Compound exercise targeting quads, hamstrings, and glutes", "Squats", 12, 4, 45, "workout-m2-w3" },
                    { "squat-m2-w4", "Compound exercise targeting quads, hamstrings, and glutes", "Squats", 8, 4, 50, "workout-m2-w4" },
                    { "squat-m2-w6", "Compound exercise targeting quads, hamstrings, and glutes", "Squats", 10, 4, 50, "workout-m2-w6" },
                    { "squat-m3-w1", "Compound exercise targeting quads, hamstrings, and glutes", "Squats", 12, 4, 50, "workout-m3-w1" },
                    { "squat-m3-w3", "Compound exercise targeting quads, hamstrings, and glutes", "Squats", 10, 4, 55, "workout-m3-w3" },
                    { "squat-m3-w4", "Compound exercise targeting quads, hamstrings, and glutes", "Squats", 12, 4, 55, "workout-m3-w4" },
                    { "squat-m3-w6", "Compound exercise targeting quads, hamstrings, and glutes", "Squats", 12, 4, 60, "workout-m3-w6" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "bench-m1-w1");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "bench-m1-w2");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "bench-m1-w4");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "bench-m1-w5");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "bench-m2-w1");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "bench-m2-w2");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "bench-m2-w4");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "bench-m2-w5");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "bench-m3-w1");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "bench-m3-w2");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "bench-m3-w4");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "bench-m3-w5");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "bicep-m1-w1");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "bicep-m1-w2");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "bicep-m1-w4");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "bicep-m1-w5");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "bicep-m2-w1");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "bicep-m2-w2");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "bicep-m2-w4");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "bicep-m2-w5");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "bicep-m3-w1");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "bicep-m3-w2");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "bicep-m3-w4");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "bicep-m3-w5");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "calf-m1-w1");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "calf-m1-w3");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "calf-m1-w4");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "calf-m1-w6");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "calf-m2-w1");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "calf-m2-w3");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "calf-m2-w4");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "calf-m2-w6");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "calf-m3-w1");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "calf-m3-w3");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "calf-m3-w4");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "calf-m3-w6");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "deadlift-m1-w1");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "deadlift-m1-w3");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "deadlift-m1-w4");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "deadlift-m1-w6");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "deadlift-m2-w1");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "deadlift-m2-w3");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "deadlift-m2-w4");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "deadlift-m2-w6");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "deadlift-m3-w1");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "deadlift-m3-w3");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "deadlift-m3-w4");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "deadlift-m3-w6");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "legpress-m1-w1");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "legpress-m1-w3");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "legpress-m1-w4");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "legpress-m1-w6");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "legpress-m2-w1");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "legpress-m2-w3");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "legpress-m2-w4");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "legpress-m2-w6");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "legpress-m3-w1");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "legpress-m3-w3");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "legpress-m3-w4");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "legpress-m3-w6");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "pullup-m1-w1");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "pullup-m1-w2");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "pullup-m1-w4");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "pullup-m1-w5");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "pullup-m2-w1");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "pullup-m2-w2");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "pullup-m2-w4");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "pullup-m2-w5");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "pullup-m3-w1");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "pullup-m3-w2");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "pullup-m3-w4");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "pullup-m3-w5");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "rdl-m1-w1");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "rdl-m1-w3");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "rdl-m1-w4");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "rdl-m1-w6");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "rdl-m2-w1");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "rdl-m2-w3");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "rdl-m2-w4");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "rdl-m2-w6");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "rdl-m3-w1");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "rdl-m3-w3");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "rdl-m3-w4");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "rdl-m3-w6");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "shoulder-m1-w1");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "shoulder-m1-w2");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "shoulder-m1-w4");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "shoulder-m1-w5");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "shoulder-m2-w1");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "shoulder-m2-w2");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "shoulder-m2-w4");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "shoulder-m2-w5");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "shoulder-m3-w1");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "shoulder-m3-w2");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "shoulder-m3-w4");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "shoulder-m3-w5");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "squat-m1-w1");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "squat-m1-w3");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "squat-m1-w4");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "squat-m1-w6");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "squat-m2-w1");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "squat-m2-w3");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "squat-m2-w4");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "squat-m2-w6");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "squat-m3-w1");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "squat-m3-w3");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "squat-m3-w4");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "squat-m3-w6");

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: "workout-m1-w1");

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: "workout-m1-w2");

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: "workout-m1-w3");

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: "workout-m1-w4");

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: "workout-m1-w5");

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: "workout-m1-w6");

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: "workout-m2-w1");

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: "workout-m2-w2");

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: "workout-m2-w3");

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: "workout-m2-w4");

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: "workout-m2-w5");

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: "workout-m2-w6");

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: "workout-m3-w1");

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: "workout-m3-w2");

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: "workout-m3-w3");

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: "workout-m3-w4");

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: "workout-m3-w5");

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: "workout-m3-w6");

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: "1a2b3c4d-5e6f-7a8b-9c0d-1e2f3a4b5c6d",
                column: "Date",
                value: new DateTime(2025, 3, 31, 22, 8, 19, 849, DateTimeKind.Local).AddTicks(4410));

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: "2b3c4d5e-6f7a-8b9c-0d1e-2f3a4b5c6d7e",
                column: "Date",
                value: new DateTime(2025, 4, 4, 22, 8, 19, 849, DateTimeKind.Local).AddTicks(4458));

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: "3c4d5e6f-7a8b-9c0d-1e2f-3a4b5c6d7e8f",
                column: "Date",
                value: new DateTime(2025, 4, 6, 22, 8, 19, 849, DateTimeKind.Local).AddTicks(4465));
        }
    }
}
