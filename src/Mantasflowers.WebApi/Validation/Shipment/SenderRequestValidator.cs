using FluentValidation;
using Mantasflowers.Contracts.Shipment.Request;

namespace Mantasflowers.WebApi.Validation.Shipment
{
    public class SenderRequestValidator : AbstractValidator<SenderRequest>
    {
        public SenderRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotNull();

            RuleFor(x => x.Phone)
                .NotNull();

            // email may be null

            RuleFor(x => x.Address)
                .NotNull();

            RuleFor(x => x.Town)
                .NotNull();

            RuleFor(x => x.County)
                .NotNull();

            RuleFor(x => x.Postcode)
                .NotNull();
        }
    }
}
