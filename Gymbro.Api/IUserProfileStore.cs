using System.Threading.Tasks;
using Gymbro.Api.Models;

namespace Gymbro.Api
{
    public interface IUserProfileStore
    {
        Task SetProfile(UserProfile userProfile);
        Task<UserProfile> GetProfile(string userId);  
    }
}