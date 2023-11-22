using FluentValidation;

namespace MonefyWeb.DistributedServices.WebApi.Validations
{
    public class AccountDataRequestValidator : AbstractValidator<long>
    {
        public AccountDataRequestValidator()
        {
            RuleFor(value => value)
                    .NotEmpty().WithMessage(Properties.Resources.ValueCannotBeEmpty)
                    .GreaterThan(0).WithMessage(Properties.Resources.ValueMustBeGreatherThan0);
        }
    }
}
