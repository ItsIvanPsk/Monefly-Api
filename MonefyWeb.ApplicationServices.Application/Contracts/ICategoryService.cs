using MonefyWeb.DomainServices.Models.Models.Categories;

namespace MonefyWeb.ApplicationServices.Application.Contracts
{
    public interface ICategoryService
    {
        List<CategoryBe> GetCategories();
        List<CategoryBe> GetCategoriesByUserId(long userId);
    }
}
