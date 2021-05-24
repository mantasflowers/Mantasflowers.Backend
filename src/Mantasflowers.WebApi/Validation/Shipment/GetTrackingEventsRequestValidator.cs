using FluentValidation;
using Mantasflowers.Contracts.Shipment.Request;

namespace Mantasflowers.WebApi.Validation.Shipment
{
    public class GetTrackingEventsRequestValidator : AbstractValidator<GetTrackingEventsRequest>
    {
        public GetTrackingEventsRequestValidator()
        {
            RuleFor(x => x.ShipmentId)
                .NotNull();
        }
    }
}
