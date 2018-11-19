using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gymbro.Api.Models;

namespace Gymbro.Api
{
    public interface IExerciseRecordStore
    {
        Task CreateExerciseRecord(ExerciseRecord exerciseRecord);
        Task<IReadOnlyCollection<ExerciseRecord>> GetExerciseRecordsForAGivenDate(string userId, DateTimeOffset date);
        Task<IReadOnlyCollection<ExerciseRecord>> GetExerciseRecordsForAGivenExercise(string userId, string exercise);
    }
}