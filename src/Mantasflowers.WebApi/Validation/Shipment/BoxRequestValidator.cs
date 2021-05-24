using FluentValidation;
using Mantasflowers.Contracts.Shipment.Request;

namespace Mantasflowers.WebApi.Validation.Shipment
{
    public class BoxRequestValidator : AbstractValidator<BoxRequest>
    {
        public BoxRequestValidator()
        {
            RuleFor(x => x.Height)
                .NotNull()
                .GreaterThan(0);

            RuleFor(x => x.Length)
                .NotNull()
                .GreaterThan(0);

            RuleFor(x => x.Weight)
                .NotNull()
                .GreaterThan(0);

            RuleFor(x => x.Width)
                .NotNull()
                .GreaterThan(0);
        }
    }
}
