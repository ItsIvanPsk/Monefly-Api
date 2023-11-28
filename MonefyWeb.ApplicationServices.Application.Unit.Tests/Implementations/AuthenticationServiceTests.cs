using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonefyWeb.ApplicationServices.Application.Contracts;
using MonefyWeb.DistributedServices.Models.Models.Users;

namespace MonefyWeb.ApplicationServices.Application.Implementations.Unit.Tests
{
    [TestClass()]
    public class AuthenticationServiceTests
    {

        [TestMethod()]
        public void GenerateTokenTest()
        {
            using var mock = AutoMock.GetLoose();
            var userResponse = new UserLoginResponseDto { };
            var expectedResult = string.Empty;

            mock.Mock<IAuthenticationService>().
                Setup(service => service.GenerateToken(userResponse)).
                Returns(expectedResult);

            var mockedStudentApplicationService = mock.Create<IAuthenticationService>();

            var result = mockedStudentApplicationService.GenerateToken(userResponse);

            mock.Mock<IAuthenticationService>().
                Verify(applicationService => applicationService.GenerateToken(userResponse));

            Console.WriteLine(expectedResult.ToString());
            Console.WriteLine(result.ToString());

            Assert.AreEqual(expectedResult, result);
        }
    }
}