using MonefyWeb.DomainServices.Models.Models;
using MonefyWeb.Infraestructure.Repository.Contracts;
using MonefyWeb.Transversal.Aspects;

namespace MonefyWeb.Infraestructure.Repository.Implementations
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [Log]
        public List<CategoryBe> GetCategories()
        {
            var categories = _dbContext.Categories
                .Select(c => new CategoryBe
                {
                    Id = c.Id,
                    Name = c.Name,
                    Icon = c.Icon,
                    Type = c.Type
                })
                .ToList();

            return categories;
        }

        [Log]
        public List<CategoryBe> GetCategoriesByUserId(long userId)
        {
            var categories = _dbContext.UsersCategories
                .Where(uc => uc.UserId == userId)
                .Select(uc => new CategoryBe
                {
                    Id = uc.Category.Id,
                    Name = uc.Category.Name,
                    Icon = uc.Category.Icon,
                    Type = uc.Category.Type
                })
                .ToList();

            return categories;
        }
    }
}
