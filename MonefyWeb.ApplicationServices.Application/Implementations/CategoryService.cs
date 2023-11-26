using AutoMapper;
using MonefyWeb.ApplicationServices.Application.Contracts;
using MonefyWeb.DomainServices.Domain.Contracts;
using MonefyWeb.DomainServices.Models.Models;
using MonefyWeb.Transversal.Aspects;

namespace MonefyWeb.ApplicationServices.Application.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryDomain _domain;
        private readonly IMapper _mapper;
        private readonly Transversal.Utils.ILogger _log;

        public CategoryService(ICategoryDomain _domain, Transversal.Utils.ILogger _log, IMapper mapper)
        {
            this._domain = _domain;
            this._log = _log;
            _mapper = mapper;
        }

        [Log]
        public List<CategoryBe> GetCategories()
        {
            return _mapper.Map<List<CategoryBe>>(_domain.GetCategories());
        }

        [Log]
        public List<CategoryBe> GetCategoriesByUserId(long UserId)
        {
            return _mapper.Map<List<CategoryBe>>(_domain.GetCategoriesByUserId(UserId));
        }
    }
}
