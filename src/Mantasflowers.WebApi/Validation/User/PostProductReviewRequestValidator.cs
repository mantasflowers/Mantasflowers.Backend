using FluentValidation;
using Mantasflowers.Contracts.Review.Request;

namespace Mantasflowers.WebApi.Validation.User
{
    public class PostProductReviewRequestValidator : AbstractValidator<PostProductReviewRequest>
    {
        public PostProductReviewRequestValidator()
        {
            RuleFor(x => x.ProductId)
                .NotEmpty();

            RuleFor(x => x.Score)
                .NotEmpty()
                .GreaterThan(0.0)
                .LessThanOrEqualTo(10.0);
        }
    }
}