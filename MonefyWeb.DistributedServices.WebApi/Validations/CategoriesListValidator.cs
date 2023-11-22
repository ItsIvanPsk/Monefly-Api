using FluentValidation;
using MonefyWeb.DistributedServices.Models.Models.Categories;

namespace MonefyWeb.DistributedServices.WebApi.Validations
{
    public class CategoriesListValidator : AbstractValidator<List<CategoryDto>>
    {
        public CategoriesListValidator()
        {
            RuleForEach(list => list)
                .SetValidator(new CategoriesValidator());
        }
    }
}