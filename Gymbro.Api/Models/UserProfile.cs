using System;

namespace Gymbro.Api.Models
{
    public class SetUserProfileRequest
    {
        public int Weight { get; set; }
        public int Height { get; set; }
        public int Age { get; set; }
    }

    public class UserProfile
    {
        public string UserId { get; set; }
        public Guid Id { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public int Age { get; set; }
         
    }
}