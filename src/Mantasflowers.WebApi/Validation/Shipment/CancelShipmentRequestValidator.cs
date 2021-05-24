using FluentValidation;
using Mantasflowers.Contracts.Shipment.Request;

namespace Mantasflowers.WebApi.Validation.Shipment
{
    public class CancelShipmentRequestValidator : AbstractValidator<CancelShipmentRequest>
    {
        public CancelShipmentRequestValidator()
        {
            RuleFor(x => x.ShipmentId)
                .NotNull();
        }
    }
}
