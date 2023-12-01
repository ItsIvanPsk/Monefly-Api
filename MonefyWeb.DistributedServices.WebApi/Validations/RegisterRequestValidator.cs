using FluentValidation;
using MonefyWeb.Transversal.Models;

namespace MonefyWeb.DistributedServices.WebApi.Validations
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequestDto>
    {
        public RegisterRequestValidator()
        {
            RuleFor(request => request.Name)
                    .NotEmpty().WithMessage(Properties.Resources.ValueCannotBeEmpty)
                    .Length(2, 50).WithMessage(Properties.Resources.LenghtMustBeInto2To50);

            RuleFor(request => request.Email)
                    .NotEmpty().WithMessage(Properties.Resources.ValueCannotBeEmpty);

            RuleFor(ac => ac.Password)
                    .NotEmpty().WithMessage(Properties.Resources.ValueCannotBeEmpty);

        }
    }
}
