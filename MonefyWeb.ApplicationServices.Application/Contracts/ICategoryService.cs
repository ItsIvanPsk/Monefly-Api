using MonefyWeb.DomainServices.Models.Models;

namespace MonefyWeb.ApplicationService.Application.Contracts
{
    public interface ICategoryService
    {
        List<CategoryBe> GetCategories();
        List<CategoryBe> GetCategoriesByUserId(long userId);
    }
}
