using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonefyWeb.DomainServices.Domain.Contracts;

namespace MonefyWeb.DomainServices.Domain.Implementations.Unit.Tests
{
    [TestClass()]
    public class AccountDomainTests
    {

        [TestMethod()]
        public void AddMovementToAccountTest()
        {
            using var mock = AutoMock.GetLoose();
            var movement = new MovementBe { };
            var expectedResult = true;

            mock.Mock<IAccountDomain>().
                Setup(domain => domain.AddMovementToAccount(movement)).
                Returns(expectedResult);

            var mockedStudentApplicationService = mock.Create<IAccountDomain>();

            var result = mockedStudentApplicationService.AddMovementToAccount(movement);

            mock.Mock<IAccountDomain>().
                Verify(domain => domain.AddMovementToAccount(movement));

            Console.WriteLine(expectedResult.ToString());
            Console.WriteLine(result.ToString());

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod()]
        public void GetAccountByUserIdTest()
        {
            using var mock = AutoMock.GetLoose();
            var UserId = 1;
            var expectedResult = new AccountBe { };

            mock.Mock<IAccountDomain>().
                Setup(domain => domain.GetAccountByUserId(UserId)).
                Returns(expectedResult);

            var mockedStudentApplicationService = mock.Create<IAccountDomain>();

            var result = mockedStudentApplicationService.GetAccountByUserId(UserId);

            mock.Mock<IAccountDomain>().
                Verify(domain => domain.GetAccountByUserId(UserId));

            Console.WriteLine(expectedResult.ToString());
            Console.WriteLine(result.ToString());

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod()]
        public void GetMovementsByAccountIdTest()
        {
            using var mock = AutoMock.GetLoose();
            var AccountId = 1;
            var expectedResult = new List<MovementBe> { };

            mock.Mock<IAccountDomain>().
                Setup(domain => domain.GetMovementsByAccountId(AccountId)).
                Returns(expectedResult);

            var mockedStudentApplicationService = mock.Create<IAccountDomain>();

            var result = mockedStudentApplicationService.GetMovementsByAccountId(AccountId);

            mock.Mock<IAccountDomain>().
                Verify(domain => domain.GetMovementsByAccountId(AccountId));

            Console.WriteLine(expectedResult.ToString());
            Console.WriteLine(result.ToString());

            Assert.AreEqual(expectedResult, result);
        }
    }
}