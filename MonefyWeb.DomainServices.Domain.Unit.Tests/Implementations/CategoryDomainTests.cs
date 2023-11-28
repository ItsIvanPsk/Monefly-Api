using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonefyWeb.DistributedServices.Models.Models.Categories;
using MonefyWeb.DomainServices.Domain.Contracts;

namespace MonefyWeb.DomainServices.Domain.Implementations.Unit.Tests
{
    [TestClass()]
    public class CategoryDomainTests
    {

        [TestMethod()]
        public void GetCategoriesTest()
        {
            using var mock = AutoMock.GetLoose();
            var expectedResult = new List<CategoryDto> { };

            mock.Mock<ICategoryDomain>().
                Setup(domain => domain.GetCategories()).
                Returns(expectedResult);

            var mockedStudentApplicationService = mock.Create<ICategoryDomain>();

            var result = mockedStudentApplicationService.GetCategories();

            mock.Mock<ICategoryDomain>().
                Verify(domain => domain.GetCategories());

            Console.WriteLine(expectedResult.ToString());
            Console.WriteLine(result.ToString());

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod()]
        public void GetCategoriesByUserIdTest()
        {
            using var mock = AutoMock.GetLoose();
            var UserId = 1;
            var expectedResult = new List<CategoryDto> { };

            mock.Mock<ICategoryDomain>().
                Setup(domain => domain.GetCategoriesByUserId(UserId)).
                Returns(expectedResult);

            var mockedStudentApplicationService = mock.Create<ICategoryDomain>();

            var result = mockedStudentApplicationService.GetCategoriesByUserId(UserId);

            mock.Mock<ICategoryDomain>().
                Verify(domain => domain.GetCategoriesByUserId(UserId));

            Console.WriteLine(expectedResult.ToString());
            Console.WriteLine(result.ToString());

            Assert.AreEqual(expectedResult, result);
        }
    }
}