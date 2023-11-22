using FluentValidation;
using MonefyWeb.DistributedServices.Models.Models.Movements;

namespace MonefyWeb.DistributedServices.WebApi.Validations
{
    public class MovementRequestValidator : AbstractValidator<MovementRequestDto>
    {
        public MovementRequestValidator()
        {
            RuleFor(movementRequest => movementRequest.AccountId).NotEmpty().WithMessage(Properties.Resources.AccountIdCannotBeEmpty);
            RuleFor(movementRequest => movementRequest.Amount).GreaterThan(0).WithMessage(Properties.Resources.AmountMustBeGreatherThan0);
            RuleFor(movementRequest => movementRequest.Concept).NotEmpty().WithMessage(Properties.Resources.ConceptCannotBeEmpty);
            RuleFor(movementRequest => movementRequest.Type).NotEmpty().WithMessage(Properties.Resources.TypeNeedsValidValue);
            RuleFor(movementRequest => movementRequest.PaymentMethod).NotEmpty().WithMessage(Properties.Resources.PaymentMethodNeedsValidValue);
            RuleFor(movementRequest => movementRequest.CategoryId).GreaterThan(0).WithMessage(Properties.Resources.CategoryTypeMustBeGreatherThan0);
        }
    }
}