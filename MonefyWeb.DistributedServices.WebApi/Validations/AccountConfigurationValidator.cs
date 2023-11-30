using FluentValidation;
using MonefyWeb.DistributedServices.Models.Models.Account_Configuration;

namespace MonefyWeb.DistributedServices.WebApi.Validations
{
    public class AccountConfigurationValidator: AbstractValidator<AccountConfigurationDto>
    {
        public AccountConfigurationValidator()
        {
            RuleFor(ac => ac.CurrencyDefault)
                    .NotEmpty().WithMessage(Properties.Resources.ValueCannotBeEmpty)
                    .LessThan(0).WithMessage(Properties.Resources.ValueMustBeGreatherThan0);

            RuleFor(ac => ac.CurrencyFormat)
                    .NotEmpty().WithMessage(Properties.Resources.ValueCannotBeEmpty)
                    .LessThan(0).WithMessage(Properties.Resources.ValueMustBeGreatherThan0);

            RuleFor(ac => ac.FirstDayWeek)
                    .NotEmpty().WithMessage(Properties.Resources.ValueCannotBeEmpty)
                    .LessThan(0).WithMessage(Properties.Resources.ValueMustBeGreatherThan0);

        }
    }
}
