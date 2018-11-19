using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gymbro.Api.Models;
using Marten;

namespace Gymbro.Api
{
    public class MartonExerciseRecordStore : IExerciseRecordStore
    {
        private IDocumentStore _documentStore;

        public MartonExerciseRecordStore(IDocumentStore documentStore)
        {
            _documentStore = documentStore;
        }
        public async Task CreateExerciseRecord(ExerciseRecord exerciseRecord)
        {
            using(var session = _documentStore.LightweightSession())
            {
                session.Store(exerciseRecord);
                await session.SaveChangesAsync();
            }
        }

        public async Task<IReadOnlyCollection<ExerciseRecord>> GetExerciseRecordsForAGivenDate(string userId, DateTimeOffset date)
        {
            using(var session = _documentStore.QuerySession())
            {   
                return await session
                    .Query<ExerciseRecord>()
                    .Where(er => er.Date == date && er.UserId == userId)
                    .ToListAsync();
            }
        }

        public async Task<IReadOnlyCollection<ExerciseRecord>> GetExerciseRecordsForAGivenExercise(string userId, string exercise)
        {
            using(var session = _documentStore.QuerySession())
            {   
                return await session
                    .Query<ExerciseRecord>()
                    .Where(er => er.Exercise == exercise && er.UserId == userId)
                    .ToListAsync();
            }
        }
    }
}