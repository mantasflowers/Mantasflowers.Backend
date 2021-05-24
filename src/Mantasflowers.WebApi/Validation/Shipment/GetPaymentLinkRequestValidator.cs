using FluentValidation;
using Mantasflowers.Contracts.Shipment.Request;

namespace Mantasflowers.WebApi.Validation.Shipment
{
    public class GetPaymentLinkRequestValidator : AbstractValidator<GetPaymentLinkRequest>
    {
        public GetPaymentLinkRequestValidator()
        {
            RuleForEach(x => x.ShipmentIds)
                .NotNull();
        }
    }
}
