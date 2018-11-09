using Gymbro.Api.Models;

namespace Gymbro.Api
{
    public interface IUserContext
    {
        User SignedInUser { get; }  
    }

    public class TempUserContext : IUserContext
    {
        public User SignedInUser => new User { Id = "001", Name = "Kim" };
    }
}