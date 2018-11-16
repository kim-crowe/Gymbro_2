using System.Threading.Tasks;
using Gymbro.Api.Models;
using Marten;

namespace Gymbro.Api
{
    public class MartonUserProfileStore : IUserProfileStore
    {
        private IDocumentStore _documentStore;

        public MartonUserProfileStore(IDocumentStore documentStore)
        {
            _documentStore = documentStore;
        }
        public async Task<UserProfile> GetProfile(string userId)
        {
            using(var session = _documentStore.QuerySession())
            {
                return await session.Query<UserProfile>().SingleOrDefaultAsync(up => up.UserId == userId);
            }
        }
        public async Task SetProfile(UserProfile userProfile)
        {
            using(var session = _documentStore.LightweightSession())
            {
                session.Store(userProfile);
                await session.SaveChangesAsync();
            }
        }
    }
}