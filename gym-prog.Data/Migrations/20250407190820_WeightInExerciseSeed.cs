using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gym_prog.Data.Migrations
{
    /// <inheritdoc />
    public partial class WeightInExerciseSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "1e2f3a4b-5c6d-7e8f-9a0b-1c2d3e4f5a6b",
                column: "Weight",
                value: 60);

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "2f3a4b5c-6d7e-8f9a-0b1c-2d3e4f5a6b7c",
                column: "Weight",
                value: 50);

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "3a4b5c6d-7e8f-9a0b-1c2d-3e4f5a6b7c8d",
                column: "Weight",
                value: 80);

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "5c6d7e8f-9a0b-1c2d-3e4f-5a6b7c8d9e0f",
                column: "Weight",
                value: 40);

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "6d7e8f9a-0b1c-2d3e-4f5a-6b7c8d9e0f1a",
                column: "Weight",
                value: 15);

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "7e8f9a0b-1c2d-3e4f-5a6b-7c8d9e0f1a2b",
                column: "Weight",
                value: 100);

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "8f9a0b1c-2d3e-4f5a-6b7c-8d9e0f1a2b3c",
                column: "Weight",
                value: 70);

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "9a0b1c2d-3e4f-5a6b-7c8d-9e0f1a2b3c4d",
                column: "Weight",
                value: 30);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "1e2f3a4b-5c6d-7e8f-9a0b-1c2d3e4f5a6b",
                column: "Weight",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "2f3a4b5c-6d7e-8f9a-0b1c-2d3e4f5a6b7c",
                column: "Weight",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "3a4b5c6d-7e8f-9a0b-1c2d-3e4f5a6b7c8d",
                column: "Weight",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "5c6d7e8f-9a0b-1c2d-3e4f-5a6b7c8d9e0f",
                column: "Weight",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "6d7e8f9a-0b1c-2d3e-4f5a-6b7c8d9e0f1a",
                column: "Weight",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "7e8f9a0b-1c2d-3e4f-5a6b-7c8d9e0f1a2b",
                column: "Weight",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "8f9a0b1c-2d3e-4f5a-6b7c-8d9e0f1a2b3c",
                column: "Weight",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "9a0b1c2d-3e4f-5a6b-7c8d-9e0f1a2b3c4d",
                column: "Weight",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: "1a2b3c4d-5e6f-7a8b-9c0d-1e2f3a4b5c6d",
                column: "Date",
                value: new DateTime(2025, 3, 31, 21, 35, 57, 720, DateTimeKind.Local).AddTicks(7819));

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: "2b3c4d5e-6f7a-8b9c-0d1e-2f3a4b5c6d7e",
                column: "Date",
                value: new DateTime(2025, 4, 4, 21, 35, 57, 720, DateTimeKind.Local).AddTicks(7876));

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: "3c4d5e6f-7a8b-9c0d-1e2f-3a4b5c6d7e8f",
                column: "Date",
                value: new DateTime(2025, 4, 6, 21, 35, 57, 720, DateTimeKind.Local).AddTicks(7884));
        }
    }
}
