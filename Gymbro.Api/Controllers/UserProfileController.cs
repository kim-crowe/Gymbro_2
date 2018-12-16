using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gymbro.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gymbro.Api.Controllers
{
    [Route("api/profile")]
    public class UserProfileController : Controller
    {       
        private IUserContext _userContext;
        private IUserProfileStore _userProfileStore;

        public UserProfileController(IUserContext userContext, IUserProfileStore userProfileStore)
        {
            _userContext = userContext;
            _userProfileStore = userProfileStore;            
        }

        [HttpPost]
        public async Task<IActionResult> CreateProfile([FromBody]SetUserProfileRequest request)
        {
            var userProfile = 
                await _userProfileStore.GetProfile(_userContext.SignedInUser.Id) 
                ?? new UserProfile { Id = Guid.NewGuid(), UserId = _userContext.SignedInUser.Id };
            
            userProfile.Age = request.Age;
            userProfile.Height = request.Height;
            userProfile.Weight = request.Weight;

            await _userProfileStore.SetProfile(userProfile);
            return Ok();
        }        

        [HttpGet]
        public async Task<IActionResult> GetProfile()
        {
            var profile = await _userProfileStore.GetProfile(_userContext.SignedInUser.Id);            
            return Json(new 
            {
                profile.Age,
                profile.Height,
                profile.Weight
            });
        }

        [HttpGet("sample")]
        public IActionResult GetSample()
        {
            var result = new SetUserProfileRequest
            {
                Age = 30,
                Height = 165,
                Weight = 165                
            };

            return Json(result);
        }
    }
}
