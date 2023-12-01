using FluentValidation;

namespace MonefyWeb.DistributedServices.WebApi.Validations
{
    public class IdValidator : AbstractValidator<long>
    {
        public IdValidator()
        {
            RuleFor(value => value)
                    .NotEmpty().WithMessage(Properties.Resources.ValueCannotBeEmpty)
                    .GreaterThan(0).WithMessage(Properties.Resources.ValueMustBeGreatherThan0);
        }
    }
}
