using FluentValidation;
using Mantasflowers.Contracts.Shipment.Request;

namespace Mantasflowers.WebApi.Validation.Shipment
{
    public class GetQuotesRequestValidator : AbstractValidator<GetQuotesRequest>
    {
        public GetQuotesRequestValidator()
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
        }
    }
}
