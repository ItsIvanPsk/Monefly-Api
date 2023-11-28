using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonefyWeb.DistributedServices.Models.Models.Users;
using MonefyWeb.DomainServices.Domain.Contracts;
using MonefyWeb.Transversal.Models;

namespace MonefyWeb.DomainServices.Domain.Implementations.Unit.Tests
{
    [TestClass()]
    public class UserDomainTests
    {

        [TestMethod()]
        public void LoginUserTest()
        {
            using var mock = AutoMock.GetLoose();
            var request = new LoginRequestDto { };
            var expectedResult = new UserLoginResponseDto { };

            mock.Mock<IUserDomain>().
                Setup(domain => domain.LoginUser(request)).
                Returns(expectedResult);

            var mockedStudentApplicationService = mock.Create<IUserDomain>();

            var result = mockedStudentApplicationService.LoginUser(request);

            mock.Mock<IUserDomain>().
                Verify(domain => domain.LoginUser(request));

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

            mock.Mock<IUserDomain>().
                Setup(domain => domain.RegisterUser(request)).
                Returns(expectedResult);

            var mockedStudentApplicationService = mock.Create<IUserDomain>();

            var result = mockedStudentApplicationService.RegisterUser(request);

            mock.Mock<IUserDomain>().
                Verify(domain => domain.RegisterUser(request));

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

            mock.Mock<IUserDomain>().
                Setup(domain => domain.GetUserData(UserId)).
                Returns(expectedResult);

            var mockedStudentApplicationService = mock.Create<IUserDomain>();

            var result = mockedStudentApplicationService.GetUserData(UserId);

            mock.Mock<IUserDomain>().
                Verify(domain => domain.GetUserData(UserId));

            Console.WriteLine(expectedResult.ToString());
            Console.WriteLine(result.ToString());

            Assert.AreEqual(expectedResult, result);
        }
    }
}