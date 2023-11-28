using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonefyWeb.ApplicationServices.Application.Contracts;
using MonefyWeb.DistributedServices.Models.Models.Users;
using MonefyWeb.Transversal.Models;

namespace MonefyWeb.ApplicationServices.Application.Implementations.Unit.Tests
{
    [TestClass()]
    public class UserServiceTests
    {

        [TestMethod()]
        public void LoginUserTest()
        {
            using var mock = AutoMock.GetLoose();
            var request = new LoginRequestDto { };
            var expectedResult = new UserLoginResponseDto { };

            mock.Mock<IUserService>().
                Setup(service => service.LoginUser(request)).
                Returns(expectedResult);

            var mockedStudentApplicationService = mock.Create<IUserService>();

            var result = mockedStudentApplicationService.LoginUser(request);

            mock.Mock<IUserService>().
                Verify(applicationService => applicationService.LoginUser(request));

            Console.WriteLine(expectedResult.ToString());
            Console.WriteLine(result.ToString());

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod()]
        public void RegisterUserTest()
        {
            using var mock = AutoMock.GetLoose();
            var request = new RegisterRequestDto { };
            var expectedResult = new UserRegisterResponseDto { };

            mock.Mock<IUserService>().
                Setup(service => service.RegisterUser(request)).
                Returns(expectedResult);

            var mockedStudentApplicationService = mock.Create<IUserService>();

            var result = mockedStudentApplicationService.RegisterUser(request);

            mock.Mock<IUserService>().
                Verify(applicationService => applicationService.RegisterUser(request));

            Console.WriteLine(expectedResult.ToString());
            Console.WriteLine(result.ToString());

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod()]
        public void GetUserDataTest()
        {
            using var mock = AutoMock.GetLoose();
            var UserId = 1;
            var expectedResult = new UserDataResponseDto { };

            mock.Mock<IUserService>().
                Setup(service => service.GetUserData(UserId)).
                Returns(expectedResult);

            var mockedStudentApplicationService = mock.Create<IUserService>();

            var result = mockedStudentApplicationService.GetUserData(UserId);

            mock.Mock<IUserService>().
                Verify(applicationService => applicationService.GetUserData(UserId));

            Console.WriteLine(expectedResult.ToString());
            Console.WriteLine(result.ToString());

            Assert.AreEqual(expectedResult, result);
        }
    }
}