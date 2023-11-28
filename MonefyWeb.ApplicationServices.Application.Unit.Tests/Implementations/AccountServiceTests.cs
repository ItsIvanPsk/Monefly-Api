using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonefyWeb.ApplicationServices.Application.Contracts;
using MonefyWeb.DistributedServices.Models.Models.Movements;
using MonefyWeb.DomainServices.Models.Models;
using MonefyWeb.Transversal.Models;
using System.Collections.Generic;

namespace MonefyWeb.ApplicationServices.Application.Implementations.Unit.Tests
{
    [TestClass()]
    public class AccountServiceTests
    {
        [TestInitialize]
        public void Initialize() { }

        [TestMethod()]
        public void AddMovementToAccountTest()
        {
            using var mock = AutoMock.GetLoose();
            var movementRequestDto = new MovementRequestDto
            {
                AccountId = 1,
                Concept = "",
                Amount = 1,
                Type = EMovementType.Add,
                PaymentMethod = EPaymentMethod.Cash,
                CategoryId = 1
            };
            var expectedResult = true;

            mock.Mock<IAccountService>().
                Setup(service => service.AddMovementToAccount(movementRequestDto)).
                Returns(expectedResult);

            var mockedStudentApplicationService = mock.Create<IAccountService>();

            var result = mockedStudentApplicationService.AddMovementToAccount(movementRequestDto);

            mock.Mock<IAccountService>().
                Verify(service => service.AddMovementToAccount(movementRequestDto));

            Console.WriteLine(expectedResult.ToString());
            Console.WriteLine(result.ToString());

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod()]
        public void AddMovementToAccountTest_ReturnsNullArgumentException()
        {
            using var mock = AutoMock.GetLoose();

            mock.Mock<IAccountService>()
                .Setup(service => service.AddMovementToAccount(null))
                .Throws(new ArgumentNullException());

            var service = mock.Create<IAccountService>();

            service.AddMovementToAccount(null);
        }

        [TestMethod()]
        public void GetAccountByUserIdTest()
        {
            using var mock = AutoMock.GetLoose();
            var userId = 1;
            var expectedResult = new AccountBe { };

            mock.Mock<IAccountService>().
                Setup(service => service.GetAccountByUserId(userId)).
                Returns(expectedResult);

            var mockedStudentApplicationService = mock.Create<IAccountService>();

            var result = mockedStudentApplicationService.GetAccountByUserId(userId);

            mock.Mock<IAccountService>().
                Verify(applicationService => applicationService.GetAccountByUserId(userId));

            Console.WriteLine(expectedResult.ToString());
            Console.WriteLine(result.ToString());

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod()]
        public void AddMovementToAccountTest_ReturnsArgumentException()
        {
            using var mock = AutoMock.GetLoose();

            mock.Mock<IAccountService>()
                .Setup(service => service.GetAccountByUserId(-1))
                .Throws(new ArgumentException());

            var service = mock.Create<IAccountService>();

            service.GetAccountByUserId(-1);
        }

        [TestMethod()]
        public void GetMovementsByAccountIdTest()
        {
            using var mock = AutoMock.GetLoose();
            var accountId = 1;
            var expectedResult = new List<MovementBe>() { };

            mock.Mock<IAccountService>().
                Setup(service => service.GetMovementsByAccountId(accountId)).
                Returns(expectedResult);

            var mockedStudentApplicationService = mock.Create<IAccountService>();

            var result = mockedStudentApplicationService.GetMovementsByAccountId(accountId);

            mock.Mock<IAccountService>().
                Verify(applicationService => applicationService.GetMovementsByAccountId(accountId));

            Console.WriteLine(expectedResult.ToString());
            Console.WriteLine(result.ToString());

            CollectionAssert.AreEqual(expectedResult, result);
        }

        [TestMethod()]
        public void GetMovementsByAccountIdTest_ReturnsArgumentException()
        {
            using var mock = AutoMock.GetLoose();

            mock.Mock<IAccountService>()
                .Setup(service => service.GetMovementsByAccountId(-1))
                .Throws(new ArgumentException());

            var service = mock.Create<IAccountService>();

            service.GetMovementsByAccountId(-1);
        }
    }
}