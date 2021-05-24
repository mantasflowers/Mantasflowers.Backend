using FluentValidation;
using Mantasflowers.Contracts.Shipment.Request;
using System;

namespace Mantasflowers.WebApi.Validation.Shipment
{
    public class CreateShipmentRequestValidator : AbstractValidator<CreateShipmentRequest>
    {
        public CreateShipmentRequestValidator()
        {
            RuleFor(x => x.Origin)
                .NotNull();

            RuleFor(x => x.Destination)
                .NotNull();

            RuleFor(x => x.GoodsValue)
                .NotNull()
                .GreaterThan(0);

            RuleForEach(x => x.Boxes)
                .NotNull()
                .SetValidator(new BoxRequestValidator());

            RuleFor(x => x.Sender)
                .NotNull()
                .SetValidator(new SenderRequestValidator());

            RuleFor(x => x.Recipient)
                .NotNull()
                .SetValidator(new RecipientRequestValidator());

            RuleFor(x => x.Service)
                .NotNull();

            RuleFor(x => x.GoodsDescription)
                .NotNull();

            RuleFor(x => x.DeliveryNotes)
                .NotNull();

            RuleFor(x => x.CollectionDate)
                .NotNull()
                .GreaterThan(DateTime.Now);

            RuleFor(x => x.Customs)
                .NotNull()
                .SetValidator(new CustomsRequestValidator());

        }
    }
}
