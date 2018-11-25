using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gymbro.Api.Models;
using Marten;

namespace Gymbro.Api
{
    public class MartenWorkoutStore : IWorkoutStore
    {
        private IDocumentStore _documentStore;

        public MartenWorkoutStore(IDocumentStore documentStore)
        {
            _documentStore = documentStore;
        }
        public async Task Update(Workout workout)
        {
            using(var session = _documentStore.LightweightSession())
            {
                session.Store(workout);
                await session.SaveChangesAsync();
            }
        }

        public async Task<IReadOnlyCollection<Workout>> Get(string userId)
        {
            using(var session = _documentStore.QuerySession())
            {   
                return await session
                    .Query<Workout>()
                    .Where(er => er.UserId == userId)
                    .ToListAsync();
            }
        }        
    }
}