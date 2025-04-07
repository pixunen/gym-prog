﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using gym_prog.Data.Data;

#nullable disable

namespace gym_prog.Data.Migrations
{
    [DbContext(typeof(GymContext))]
    partial class GymContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("gym_prog.Data.Entities.Exercise", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Reps")
                        .HasColumnType("int");

                    b.Property<int>("Sets")
                        .HasColumnType("int");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.Property<string>("WorkoutId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("WorkoutId");

                    b.ToTable("Exercises");

                    b.HasData(
                        new
                        {
                            Id = "1e2f3a4b-5c6d-7e8f-9a0b-1c2d3e4f5a6b",
                            Description = "Compound exercise targeting quads, hamstrings, and glutes",
                            Name = "Squats",
                            Reps = 12,
                            Sets = 4,
                            Weight = 0,
                            WorkoutId = "1a2b3c4d-5e6f-7a8b-9c0d-1e2f3a4b5c6d"
                        },
                        new
                        {
                            Id = "2f3a4b5c-6d7e-8f9a-0b1c-2d3e4f5a6b7c",
                            Description = "Compound exercise for chest, shoulders, and triceps",
                            Name = "Bench Press",
                            Reps = 10,
                            Sets = 3,
                            Weight = 0,
                            WorkoutId = "1a2b3c4d-5e6f-7a8b-9c0d-1e2f3a4b5c6d"
                        },
                        new
                        {
                            Id = "3a4b5c6d-7e8f-9a0b-1c2d-3e4f5a6b7c8d",
                            Description = "Full body compound exercise emphasizing posterior chain",
                            Name = "Deadlifts",
                            Reps = 8,
                            Sets = 4,
                            Weight = 0,
                            WorkoutId = "1a2b3c4d-5e6f-7a8b-9c0d-1e2f3a4b5c6d"
                        },
                        new
                        {
                            Id = "4b5c6d7e-8f9a-0b1c-2d3e-4f5a6b7c8d9e",
                            Description = "Bodyweight exercise targeting back and biceps",
                            Name = "Pull-ups",
                            Reps = 8,
                            Sets = 3,
                            Weight = 0,
                            WorkoutId = "2b3c4d5e-6f7a-8b9c-0d1e-2f3a4b5c6d7e"
                        },
                        new
                        {
                            Id = "5c6d7e8f-9a0b-1c2d-3e4f-5a6b7c8d9e0f",
                            Description = "Overhead press targeting deltoids and triceps",
                            Name = "Shoulder Press",
                            Reps = 12,
                            Sets = 3,
                            Weight = 0,
                            WorkoutId = "2b3c4d5e-6f7a-8b9c-0d1e-2f3a4b5c6d7e"
                        },
                        new
                        {
                            Id = "6d7e8f9a-0b1c-2d3e-4f5a-6b7c8d9e0f1a",
                            Description = "Isolation exercise for biceps",
                            Name = "Bicep Curls",
                            Reps = 15,
                            Sets = 3,
                            Weight = 0,
                            WorkoutId = "2b3c4d5e-6f7a-8b9c-0d1e-2f3a4b5c6d7e"
                        },
                        new
                        {
                            Id = "7e8f9a0b-1c2d-3e4f-5a6b-7c8d9e0f1a2b",
                            Description = "Machine-based compound leg exercise",
                            Name = "Leg Press",
                            Reps = 12,
                            Sets = 4,
                            Weight = 0,
                            WorkoutId = "3c4d5e6f-7a8b-9c0d-1e2f-3a4b5c6d7e8f"
                        },
                        new
                        {
                            Id = "8f9a0b1c-2d3e-4f5a-6b7c-8d9e0f1a2b3c",
                            Description = "Targets hamstrings and lower back",
                            Name = "Romanian Deadlifts",
                            Reps = 10,
                            Sets = 3,
                            Weight = 0,
                            WorkoutId = "3c4d5e6f-7a8b-9c0d-1e2f-3a4b5c6d7e8f"
                        },
                        new
                        {
                            Id = "9a0b1c2d-3e4f-5a6b-7c8d-9e0f1a2b3c4d",
                            Description = "Isolation exercise for calf muscles",
                            Name = "Calf Raises",
                            Reps = 20,
                            Sets = 4,
                            Weight = 0,
                            WorkoutId = "3c4d5e6f-7a8b-9c0d-1e2f-3a4b5c6d7e8f"
                        });
                });

            modelBuilder.Entity("gym_prog.Data.Entities.Workout", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Workouts");

                    b.HasData(
                        new
                        {
                            Id = "1a2b3c4d-5e6f-7a8b-9c0d-1e2f3a4b5c6d",
                            Date = new DateTime(2025, 3, 31, 21, 35, 57, 720, DateTimeKind.Local).AddTicks(7819),
                            Description = "A comprehensive workout that targets all major muscle groups",
                            Name = "Full Body Workout"
                        },
                        new
                        {
                            Id = "2b3c4d5e-6f7a-8b9c-0d1e-2f3a4b5c6d7e",
                            Date = new DateTime(2025, 4, 4, 21, 35, 57, 720, DateTimeKind.Local).AddTicks(7876),
                            Description = "Targets chest, shoulders, back, and arms",
                            Name = "Upper Body Focus"
                        },
                        new
                        {
                            Id = "3c4d5e6f-7a8b-9c0d-1e2f-3a4b5c6d7e8f",
                            Date = new DateTime(2025, 4, 6, 21, 35, 57, 720, DateTimeKind.Local).AddTicks(7884),
                            Description = "Focuses on quads, hamstrings, calves, and glutes",
                            Name = "Lower Body Strength"
                        });
                });

            modelBuilder.Entity("gym_prog.Data.Entities.Exercise", b =>
                {
                    b.HasOne("gym_prog.Data.Entities.Workout", "Workout")
                        .WithMany("Exercises")
                        .HasForeignKey("WorkoutId");

                    b.Navigation("Workout");
                });

            modelBuilder.Entity("gym_prog.Data.Entities.Workout", b =>
                {
                    b.Navigation("Exercises");
                });
#pragma warning restore 612, 618
        }
    }
}
