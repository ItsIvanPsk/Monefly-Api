using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonefyWeb.DomainServices.Models.Models;
using MonefyWeb.Infraestructure.Repository.Contracts;

namespace MonefyWeb.Infraestructure.Repository.Implementations.Unit.Tests
{
    [TestClass()]
    public class CategoryRepositoryTests
    {

        [TestMethod()]
        public void GetCategoriesTest()
        {
            using var mock = AutoMock.GetLoose();
            var accountId = 1;
            var expectedResult = new List<MovementBe> { };

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

        [TestMethod()]
        public void GetCategoriesByUserIdTest()
        {
            using var mock = AutoMock.GetLoose();
            var accountId = 1;
            var expectedResult = new List<MovementBe> { };

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