using MonefyWeb.DomainServices.Models.Models.Categories;

namespace MonefyWeb.Infraestructure.Repository.Contracts
{
    public interface ICategoryRepository
    {
        List<CategoryBe> GetCategories();

        List<CategoryBe> GetCategoriesByUserId(long userId);
    }
}
