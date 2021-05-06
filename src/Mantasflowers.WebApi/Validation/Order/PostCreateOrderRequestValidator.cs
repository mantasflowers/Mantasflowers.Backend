using FluentValidation;
using Mantasflowers.Contracts.Order.Request;

namespace Mantasflowers.WebApi.Validation.Order
{
    public class PostCreateOrderRequestValidator : AbstractValidator<PostCreateOrderRequest>
    {
        public PostCreateOrderRequestValidator()
        {
            RuleFor(x => x.Address)
                .SetValidator(new PostOrderAddressRequestValidator());

            RuleFor(x => x.ContactDetails)
                .SetValidator(new PostOrderContactDetailsRequestValidator());

            RuleFor(x => x.Message)
                .NotNull();

            RuleForEach(x => x.OrderItems)
                .NotEmpty()
                .SetValidator(new PostOrderItemRequestValidator());
        }
    }
}
