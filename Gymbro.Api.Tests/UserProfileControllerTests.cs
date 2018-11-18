using System;
using System.Threading.Tasks;
using FluentAssertions;
using Gymbro.Api.Controllers;
using Gymbro.Api.Models;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Xunit;

namespace Gymbro.Api.Tests
{
    public class UserProfileControllerTests
    {
        private IUserContext _mockUserContext;

        public UserProfileControllerTests()
        {
            _mockUserContext = Substitute.For<IUserContext>();
            _mockUserContext.SignedInUser.Returns(new User
            {
                Id = "001",
                Name = "Test"
            });
        }

        [Fact]
        public async Task CreatesNewRecord_WhenUserProfile_DoesNotExist()
        {
            UserProfile userProfile = null;
            var mockUserProfileStore = Substitute.For<IUserProfileStore>();
            mockUserProfileStore.GetProfile(Arg.Any<string>()).Returns(Task.FromResult<UserProfile>(null));
            mockUserProfileStore.WhenForAnyArgs(x => x.SetProfile(null)).Do(x => userProfile = x.ArgAt<UserProfile>(0));
            
            var controller = new UserProfileController(_mockUserContext, mockUserProfileStore);
            await controller.SetProfile(new SetUserProfileRequest
            {
                Age = 1,
                Height = 2,
                Weight = 3
            });

            userProfile.Should().NotBeNull();
            userProfile.Age.Should().Be(1);
            userProfile.Height.Should().Be(2);
            userProfile.Weight.Should().Be(3);
            userProfile.Id.Should().NotBeEmpty();
            userProfile.UserId.Should().Be("001");   
        }

        [Fact]
        public async Task UpdatesExistingRecord_WhenUserProfile_DoesExist()
        {
            UserProfile actualUserProfile = null;

            var existingUserProfile = new UserProfile
            {
                UserId = "001",
                Id = new Guid(),
                Weight = 10,
                Height = 20,
                Age = 30
            };

            var mockUserProfileStore = Substitute.For<IUserProfileStore>();
            mockUserProfileStore.GetProfile(Arg.Any<string>()).Returns(Task.FromResult<UserProfile>(existingUserProfile));
            mockUserProfileStore.WhenForAnyArgs(x => x.SetProfile(null)).Do(x => actualUserProfile = x.ArgAt<UserProfile>(0));
            var controller = new UserProfileController(_mockUserContext, mockUserProfileStore);
            await controller.SetProfile(new SetUserProfileRequest
            {
                Weight = 3,
                Height = 2,
                Age = 1
            });

            actualUserProfile.Should().NotBeNull();
            actualUserProfile.Weight.Should().Be(3);
            actualUserProfile.Height.Should().Be(2);
            actualUserProfile.Age.Should().Be(1);
            actualUserProfile.Id.Should().Be(existingUserProfile.Id);
            actualUserProfile.UserId.Should().Be("001");
        }       
    }
}
