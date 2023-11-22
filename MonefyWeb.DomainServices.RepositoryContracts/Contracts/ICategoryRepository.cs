using MonefyWeb.DomainServices.Models.Models;

namespace MonefyWeb.Infraestructure.Repository.Contracts
{
    public interface ICategoryRepository
    {
        List<CategoryBe> GetCategories();

        List<CategoryBe> GetCategoriesByUserId(long userId);
    }
}
