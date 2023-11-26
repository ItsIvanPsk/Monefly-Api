using MonefyWeb.DomainServices.Models.Models;

namespace MonefyWeb.ApplicationServices.Application.Contracts
{
    public interface ICategoryService
    {
        List<CategoryBe> GetCategories();
        List<CategoryBe> GetCategoriesByUserId(long userId);
    }
}
