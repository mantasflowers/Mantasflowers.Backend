using FluentValidation;
using Mantasflowers.Contracts.Order.Request;

namespace Mantasflowers.WebApi.Validation.Order
{
    public class PostOrderItemRequestValidator : AbstractValidator<PostOrderItemRequest>
    {
        public PostOrderItemRequestValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();

            RuleFor(x => x.Quantity)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(x => x.UnitPrice)
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
