using Moq;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;

namespace SocialNetwork.Tests.Services.Tests
{
    public class UserServiceTests
    {
        [Test]
        public void RegisterShouldNotThrowException()
        {
            var mockUserRepository = new Mock<IUserRepository>();

            UserEntity nullUserEntity = null;

            mockUserRepository.Setup(m => m.Create(It.IsAny<UserEntity>())).Returns(1);
            mockUserRepository.Setup(m => m.FindByEmail(It.IsAny<string>())).Returns(nullUserEntity);

            var userService = new UserService(mockUserRepository.Object);

            var userRegData = new UserRegistrationData();
            userRegData.FirstName = "Test";
            userRegData.LastName = "Test";
            userRegData.Email = "test@yandex.ru";
            userRegData.Password = "qwerty123";

            Assert.DoesNotThrow(() => userService.Register(userRegData));
        }
    }
}