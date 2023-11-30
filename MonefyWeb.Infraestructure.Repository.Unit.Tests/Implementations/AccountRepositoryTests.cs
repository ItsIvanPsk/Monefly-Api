using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonefyWeb.DomainServices.Models.Models;
using MonefyWeb.Infraestructure.Models;
using MonefyWeb.Infraestructure.Repository.Contracts;

namespace MonefyWeb.Infraestructure.Repository.Implementations.Unit.Tests
{
    [TestClass()]
    public class AccountRepositoryTests
    {

        [TestMethod()]
        public void AddMovementToAccountTest()
        {
            using var mock = AutoMock.GetLoose();
            var movement = new MovementDm { };
            var expectedResult = true;

            mock.Mock<IAccountRepository>().
                Setup(repository => repository.AddMovementToAccount(movement)).
                Returns(expectedResult);

            var mockedStudentApplicationService = mock.Create<IAccountRepository>();

            var result = mockedStudentApplicationService.AddMovementToAccount(movement);

            mock.Mock<IAccountRepository>().
                Verify(repository => repository.AddMovementToAccount(movement));

            Console.WriteLine(expectedResult.ToString());
            Console.WriteLine(result.ToString());

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod()]
        public void GetAccountByUserIdTest()
        {
            using var mock = AutoMock.GetLoose();
            var UserId = 1;
            var expectedResult = new AccountDm { };

            mock.Mock<IAccountRepository>().
                Setup(repository => repository.GetAccountByUserId(UserId)).
                Returns(expectedResult);

            var mockedStudentApplicationService = mock.Create<IAccountRepository>();

            var result = mockedStudentApplicationService.GetAccountByUserId(UserId);

            mock.Mock<IAccountRepository>().
                Verify(repository => repository.GetAccountByUserId(UserId));

            Console.WriteLine(expectedResult.ToString());
            Console.WriteLine(result.ToString());

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod()]
        public void GetMovementsByAccountIdTest()
        {
            using var mock = AutoMock.GetLoose();
            var accountId = 1;
            var expectedResult = new List<MovementDm> { };

            mock.Mock<IAccountRepository>().
                Setup(repository => repository.GetMovementsByAccountId(accountId)).
                Returns(expectedResult);

            var mockedStudentApplicationService = mock.Create<IAccountRepository>();

            var result = mockedStudentApplicationService.GetMovementsByAccountId(accountId);

            mock.Mock<IAccountRepository>().
                Verify(repository => repository.GetMovementsByAccountId(accountId));

            Console.WriteLine(expectedResult.ToString());
            Console.WriteLine(result.ToString());

            Assert.AreEqual(expectedResult, result);
        }
    }
}