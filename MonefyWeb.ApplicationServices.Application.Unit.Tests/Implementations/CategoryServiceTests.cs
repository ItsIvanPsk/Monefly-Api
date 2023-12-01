using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonefyWeb.ApplicationServices.Application.Contracts;

namespace MonefyWeb.ApplicationServices.Application.Implementations.Unit.Tests
{
    [TestClass()]
    public class CategoryServiceTests
    {

        [TestMethod()]
        public void GetCategoriesTest()
        {
            using var mock = AutoMock.GetLoose();
            var expectedResult = new List<CategoryBe> { };

            mock.Mock<ICategoryService>().
                Setup(service => service.GetCategories()).
                Returns(expectedResult);

            var mockedStudentApplicationService = mock.Create<ICategoryService>();

            var result = mockedStudentApplicationService.GetCategories();

            mock.Mock<ICategoryService>().
                Verify(applicationService => applicationService.GetCategories());

            Console.WriteLine(expectedResult.ToString());
            Console.WriteLine(result.ToString());

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod()]
        public void GetCategoriesByUserIdTest()
        {
            using var mock = AutoMock.GetLoose();
            var UserId = 1;
            var expectedResult = new List<CategoryBe> { };

            mock.Mock<ICategoryService>().
                Setup(service => service.GetCategoriesByUserId(UserId)).
                Returns(expectedResult);

            var mockedStudentApplicationService = mock.Create<ICategoryService>();

            var result = mockedStudentApplicationService.GetCategoriesByUserId(UserId);

            mock.Mock<ICategoryService>().
                Verify(applicationService => applicationService.GetCategoriesByUserId(UserId));

            Console.WriteLine(expectedResult.ToString());
            Console.WriteLine(result.ToString());

            Assert.AreEqual(expectedResult, result);
        }
    }
}