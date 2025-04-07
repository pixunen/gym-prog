using System.Runtime.CompilerServices;
using gym_prog.Data.Entities;
using gym_prog.Shared.Dtos;

namespace gym_prog.Logic.Mapping
{
    /// <summary>
    /// Simple mapping utility for converting between entities and DTOs
    /// </summary>
    public static class Mapper
    {
        #region Entity to DTO
        /// <summary>
        /// Maps a Workout entity to a WorkoutDto
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static WorkoutDto? ToDto(this Workout? entity)
        {
            return entity is null
                ? null
                : new WorkoutDto
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Description = entity.Description,
                    Date = entity.Date,
                    Exercises = entity.Exercises?.Select(e => e.ToDto()!).ToList() ?? []
                };
        }

        /// <summary>
        /// Maps an Exercise entity to an ExerciseDto
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ExerciseDto? ToDto(this Exercise? entity)
        {
            return entity is null
                ? null
                : new ExerciseDto
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Description = entity.Description,
                    Sets = entity.Sets,
                    Reps = entity.Reps,
                    Weight = entity.Weight,
                    WorkoutId = entity.WorkoutId ?? string.Empty
                };
        }

        /// <summary>
        /// Maps a collection of Workout entities to WorkoutDtos
        /// </summary>
        public static List<WorkoutDto> ToDtos(this IEnumerable<Workout>? entities) => entities is null ? [] : [.. entities.Select(e => e.ToDto()!)];
        #endregion

        #region DTO to Entity
        /// <summary>
        /// Maps a WorkoutDto to a Workout entity
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Workout? ToEntity(this WorkoutDto? dto)
        {
            return dto is null
                ? null
                : new Workout
                {
                    Id = dto.Id,
                    Name = dto.Name,
                    Description = dto.Description,
                    Date = dto.Date,
                    Exercises = dto.Exercises?.Select(e => e.ToEntity()!).ToList() ?? []
                };
        }

        /// <summary>
        /// Maps an ExerciseDto to an Exercise entity
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Exercise? ToEntity(this ExerciseDto? dto)
        {
            return dto is null
                ? null
                : new Exercise
                {
                    Id = dto.Id,
                    Name = dto.Name,
                    Description = dto.Description,
                    Sets = dto.Sets,
                    Reps = dto.Reps,
                    Weight = dto.Weight,
                    WorkoutId = dto.WorkoutId
                };
        }
        #endregion
    }
}
