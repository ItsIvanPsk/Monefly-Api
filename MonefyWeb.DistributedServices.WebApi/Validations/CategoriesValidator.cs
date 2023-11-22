using FluentValidation;
using MonefyWeb.DistributedServices.Models.Models.Categories;

namespace MonefyWeb.DistributedServices.WebApi.Validations
{
    public class CategoriesValidator : AbstractValidator<CategoryDto>
    {
        public CategoriesValidator()
        {
            RuleFor(category => category.Name)
                .NotEmpty().WithMessage(Properties.Resources.NameCannotBeNull)
                .Length(2, 50).WithMessage(Properties.Resources.LenghtMustBeInto2To50);

            RuleFor(category => category.Icon)
                .NotEmpty().WithMessage(Properties.Resources.TheIconCannotBeEmpty);
        }
    }
}
