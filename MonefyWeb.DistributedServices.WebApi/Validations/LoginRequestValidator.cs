using FluentValidation;
using MonefyWeb.Transversal.Models;

namespace MonefyWeb.DistributedServices.WebApi.Validations
{
    public class LoginRequestValidator : AbstractValidator<LoginRequestDto>
    {
        public LoginRequestValidator()
        {
            RuleFor(request => request.Name)
                    .NotEmpty().WithMessage(Properties.Resources.ValueCannotBeEmpty)
                    .Length(2, 50).WithMessage(Properties.Resources.LenghtMustBeInto2To50);

            RuleFor(ac => ac.Password)
                    .NotEmpty().WithMessage(Properties.Resources.ValueCannotBeEmpty);

        }
    }
}
