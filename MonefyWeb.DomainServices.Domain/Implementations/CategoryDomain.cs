using AutoMapper;
using MonefyWeb.DistributedServices.Models.Models.Categories;
using MonefyWeb.DomainServices.Domain.Contracts;
using MonefyWeb.Infraestructure.Repository.Contracts;
using MonefyWeb.Transversal.Aspects;

namespace MonefyWeb.DomainServices.Domain.Implementations
{
    public class CategoryDomain : ICategoryDomain
    {
        private readonly ICategoryRepository _category;
        private readonly IMapper _mapper;
        private readonly Transversal.Utils.ILogger _log;

        public CategoryDomain(
            ICategoryRepository _category,
            Transversal.Utils.ILogger _log,
            IMapper mapper
        )
        {
            this._category = _category;
            this._log = _log;
            this._mapper = mapper;
        }

        [Log]
        public List<CategoryDto> GetCategories()
        {
            return _mapper.Map<List<CategoryDto>>(_category.GetCategories());
        }

        [Log]
        public List<CategoryDto> GetCategoriesByUserId(long UserId)
        {
            return _mapper.Map<List<CategoryDto>>(_category.GetCategoriesByUserId(UserId));
        }
    }
}
