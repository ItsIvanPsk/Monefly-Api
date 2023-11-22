using MonefyWeb.DistributedServices.Models.Models.Categories;

namespace MonefyWeb.DomainServices.Domain.Contracts
{
    public interface ICategoryDomain
    {
        List<CategoryDto> GetCategories();
        List<CategoryDto> GetCategoriesByUserId(long userId);
    }
}
