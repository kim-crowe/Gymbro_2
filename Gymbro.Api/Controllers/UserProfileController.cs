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
    [AllowAnonymous]
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
        public async Task<IActionResult> SetProfile(UserProfile userProfile)
        {
            if (_userContext.SignedInUser.Id != userProfile.UserId)
            {
                return Forbid();
            }
            await _userProfileStore.SetProfile(userProfile);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetProfile()
        {
            var profile = await _userProfileStore.GetProfile(_userContext.SignedInUser.Id);
            return Json(profile);
        }

        [HttpGet("sample")]
        public IActionResult GetSample()
        {
            var result = new UserProfile
            {
                Age = 30,
                Height = 165,
                Weight = 165,
                UserId = _userContext.SignedInUser.Id,
                Id = Guid.NewGuid()
            };

            return Json(result);
        }
    }
}
