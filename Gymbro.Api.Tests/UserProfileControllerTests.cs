using System;
using System.Threading.Tasks;
using Gymbro.Api.Controllers;
using Gymbro.Api.Models;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Xunit;

namespace Gymbro.Api.Tests
{
    public class UserProfileControllerTests
    {
        [Fact]
        public async Task ReturnsForbidden_WhenUserProfileId_DoesNotMatch()
        {
            var userProfile = new UserProfile
            {
                UserId = "0001"
            };

            var signedInUser = new User
            {
                Id = "0002"
            };

            var mockUserContext = Substitute.For<IUserContext>();
            mockUserContext.SignedInUser.Returns(signedInUser);
            var mockUserProfileStore = Substitute.For<IUserProfileStore>();
            var controller = new UserProfileController(mockUserContext, mockUserProfileStore);
            
            var result = await controller.SetProfile(userProfile);          
            Assert.IsAssignableFrom<ForbidResult>(result);  
        }

        [Fact]
        public async Task ReturnsOK_WhenUserProfileId_DoesMatch()
        {
            var userProfile = new UserProfile
            {
                UserId = "0001"
            };

            var signedInUser = new User
            {
                Id = "0001"
            };

            var mockUserContext = Substitute.For<IUserContext>();
            mockUserContext.SignedInUser.Returns(signedInUser);
            var mockUserProfileStore = Substitute.For<IUserProfileStore>();
            var controller = new UserProfileController(mockUserContext, mockUserProfileStore);
            
            var result = await controller.SetProfile(userProfile);          
            Assert.IsAssignableFrom<OkResult>(result);  
        }
    }
}
