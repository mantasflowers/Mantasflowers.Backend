using FluentValidation;
using Mantasflowers.Contracts.Shipment.Request;

namespace Mantasflowers.WebApi.Validation.Shipment
{
    public class ItemRequestValidator : AbstractValidator<ItemRequest>
    {
        public ItemRequestValidator()
        {
            RuleFor(x => x.Quantity)
                .NotNull()
                .GreaterThan(0);

            RuleFor(x => x.Description)
                .NotNull();

            RuleFor(x => x.ValuePerUnit)
                .NotNull()
                .GreaterThan(0);
        }
    }
}
