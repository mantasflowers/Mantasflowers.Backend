using FluentValidation;
using Mantasflowers.Contracts.Payment.Request;
using Mantasflowers.WebApi.Validation.Order;

namespace Mantasflowers.WebApi.Validation.Payment
{
    public class PostCreateCheckoutSessionRequestValidator : AbstractValidator<PostCreateCheckoutSessionRequest>
    {
        public PostCreateCheckoutSessionRequestValidator()
        {
            RuleFor(x => x.Cancelurl)
                .NotEmpty();

            RuleFor(x => x.SuccessUrl)
                .NotEmpty();

            RuleFor(x => x.Order)
                .NotEmpty()
                .SetValidator(new PostCreateOrderRequestValidator());
        }
    }
}
