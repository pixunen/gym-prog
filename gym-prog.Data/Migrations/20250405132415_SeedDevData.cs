using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace gym_prog.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedDevData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_Workouts_WorkoutId",
                table: "Exercises");

            migrationBuilder.AlterColumn<string>(
                name: "WorkoutId",
                table: "Exercises",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.InsertData(
                table: "Workouts",
                columns: new[] { "Id", "Date", "Description", "Name" },
                values: new object[,]
                {
                    { "1a2b3c4d-5e6f-7a8b-9c0d-1e2f3a4b5c6d", new DateTime(2025, 3, 29, 16, 24, 14, 752, DateTimeKind.Local).AddTicks(2099), "A comprehensive workout that targets all major muscle groups", "Full Body Workout" },
                    { "2b3c4d5e-6f7a-8b9c-0d1e-2f3a4b5c6d7e", new DateTime(2025, 4, 2, 16, 24, 14, 752, DateTimeKind.Local).AddTicks(2144), "Targets chest, shoulders, back, and arms", "Upper Body Focus" },
                    { "3c4d5e6f-7a8b-9c0d-1e2f-3a4b5c6d7e8f", new DateTime(2025, 4, 4, 16, 24, 14, 752, DateTimeKind.Local).AddTicks(2151), "Focuses on quads, hamstrings, calves, and glutes", "Lower Body Strength" }
                });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "Description", "Name", "Reps", "Sets", "WorkoutId" },
                values: new object[,]
                {
                    { "1e2f3a4b-5c6d-7e8f-9a0b-1c2d3e4f5a6b", "Compound exercise targeting quads, hamstrings, and glutes", "Squats", 12, 4, "1a2b3c4d-5e6f-7a8b-9c0d-1e2f3a4b5c6d" },
                    { "2f3a4b5c-6d7e-8f9a-0b1c-2d3e4f5a6b7c", "Compound exercise for chest, shoulders, and triceps", "Bench Press", 10, 3, "1a2b3c4d-5e6f-7a8b-9c0d-1e2f3a4b5c6d" },
                    { "3a4b5c6d-7e8f-9a0b-1c2d-3e4f5a6b7c8d", "Full body compound exercise emphasizing posterior chain", "Deadlifts", 8, 4, "1a2b3c4d-5e6f-7a8b-9c0d-1e2f3a4b5c6d" },
                    { "4b5c6d7e-8f9a-0b1c-2d3e-4f5a6b7c8d9e", "Bodyweight exercise targeting back and biceps", "Pull-ups", 8, 3, "2b3c4d5e-6f7a-8b9c-0d1e-2f3a4b5c6d7e" },
                    { "5c6d7e8f-9a0b-1c2d-3e4f-5a6b7c8d9e0f", "Overhead press targeting deltoids and triceps", "Shoulder Press", 12, 3, "2b3c4d5e-6f7a-8b9c-0d1e-2f3a4b5c6d7e" },
                    { "6d7e8f9a-0b1c-2d3e-4f5a-6b7c8d9e0f1a", "Isolation exercise for biceps", "Bicep Curls", 15, 3, "2b3c4d5e-6f7a-8b9c-0d1e-2f3a4b5c6d7e" },
                    { "7e8f9a0b-1c2d-3e4f-5a6b-7c8d9e0f1a2b", "Machine-based compound leg exercise", "Leg Press", 12, 4, "3c4d5e6f-7a8b-9c0d-1e2f-3a4b5c6d7e8f" },
                    { "8f9a0b1c-2d3e-4f5a-6b7c-8d9e0f1a2b3c", "Targets hamstrings and lower back", "Romanian Deadlifts", 10, 3, "3c4d5e6f-7a8b-9c0d-1e2f-3a4b5c6d7e8f" },
                    { "9a0b1c2d-3e4f-5a6b-7c8d-9e0f1a2b3c4d", "Isolation exercise for calf muscles", "Calf Raises", 20, 4, "3c4d5e6f-7a8b-9c0d-1e2f-3a4b5c6d7e8f" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_Workouts_WorkoutId",
                table: "Exercises",
                column: "WorkoutId",
                principalTable: "Workouts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_Workouts_WorkoutId",
                table: "Exercises");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "1e2f3a4b-5c6d-7e8f-9a0b-1c2d3e4f5a6b");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "2f3a4b5c-6d7e-8f9a-0b1c-2d3e4f5a6b7c");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "3a4b5c6d-7e8f-9a0b-1c2d-3e4f5a6b7c8d");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "4b5c6d7e-8f9a-0b1c-2d3e-4f5a6b7c8d9e");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "5c6d7e8f-9a0b-1c2d-3e4f-5a6b7c8d9e0f");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "6d7e8f9a-0b1c-2d3e-4f5a-6b7c8d9e0f1a");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "7e8f9a0b-1c2d-3e4f-5a6b-7c8d9e0f1a2b");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "8f9a0b1c-2d3e-4f5a-6b7c-8d9e0f1a2b3c");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "9a0b1c2d-3e4f-5a6b-7c8d-9e0f1a2b3c4d");

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: "1a2b3c4d-5e6f-7a8b-9c0d-1e2f3a4b5c6d");

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: "2b3c4d5e-6f7a-8b9c-0d1e-2f3a4b5c6d7e");

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: "3c4d5e6f-7a8b-9c0d-1e2f-3a4b5c6d7e8f");

            migrationBuilder.AlterColumn<string>(
                name: "WorkoutId",
                table: "Exercises",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_Workouts_WorkoutId",
                table: "Exercises",
                column: "WorkoutId",
                principalTable: "Workouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
