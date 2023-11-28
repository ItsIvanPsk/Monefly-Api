using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonefyWeb.DomainServices.Models.Models;
using MonefyWeb.Infraestructure.Repository.Contracts;
using MonefyWeb.Transversal.Models;

namespace MonefyWeb.Infraestructure.Repository.Implementations.Unit.Tests
{
    [TestClass()]
    public class UserRepositoryTests
    {

        [TestMethod()]
        public void GetUserDataTest()
        {
            using var mock = AutoMock.GetLoose();
            var accountId = 1;
            var expectedResult = new UserDataResponseBe { };

            mock.Mock<IUserRepository>().
                Setup(repository => repository.GetUserData(accountId)).
                Returns(expectedResult);

            var mockedStudentApplicationService = mock.Create<IUserRepository>();

            var result = mockedStudentApplicationService.GetUserData(accountId);

            mock.Mock<IUserRepository>().
                Verify(repository => repository.GetUserData(accountId));

            Console.WriteLine(expectedResult.ToString());
            Console.WriteLine(result.ToString());

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod()]
        public void LoginUserTest()
        {
            using var mock = AutoMock.GetLoose();
            var accountId = new LoginRequestDto { };
            var expectedResult = new UserLoginResponseBe { };

            mock.Mock<IUserRepository>().
                Setup(repository => repository.LoginUser(accountId)).
                Returns(expectedResult);

            var mockedStudentApplicationService = mock.Create<IUserRepository>();

            var result = mockedStudentApplicationService.LoginUser(accountId);

            mock.Mock<IUserRepository>().
                Verify(repository => repository.LoginUser(accountId));

            Console.WriteLine(expectedResult.ToString());
            Console.WriteLine(result.ToString());

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod()]
        public void RegisterUserTest()
        {
            using var mock = AutoMock.GetLoose();
            var accountId = new RegisterRequestDto { };
            var expectedResult = new UserRegisterResponseBe { };

            mock.Mock<IUserRepository>().
                Setup(repository => repository.RegisterUser(accountId)).
                Returns(expectedResult);

            var mockedStudentApplicationService = mock.Create<IUserRepository>();

            var result = mockedStudentApplicationService.RegisterUser(accountId);

            mock.Mock<IUserRepository>().
                Verify(repository => repository.RegisterUser(accountId));

            Console.WriteLine(expectedResult.ToString());
            Console.WriteLine(result.ToString());

            Assert.AreEqual(expectedResult, result);
        }
    }
}