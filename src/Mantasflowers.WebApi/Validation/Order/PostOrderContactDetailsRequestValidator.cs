using FluentValidation;
using Mantasflowers.Contracts.Order.Request;

namespace Mantasflowers.WebApi.Validation.Order
{
    public class PostOrderContactDetailsRequestValidator : AbstractValidator<PostOrderContactDetailsRequest>
    {
        public PostOrderContactDetailsRequestValidator()
        {
            RuleFor(x => x.Email)
                .NotNull();

            RuleFor(x => x.Phone)
                .NotEmpty();
        }
    }
}
