using FluentValidation;
using Mantasflowers.Contracts.Payment.Request;
using System;

namespace Mantasflowers.WebApi.Validation.Payment
{
    public class PostCreateCouponRequestValidator : AbstractValidator<PostCreateCouponRequest>
    {
        public PostCreateCouponRequestValidator()
        {
            RuleFor(x => x.DiscountPrice)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(x => x.DurationInMonths)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(x => x.Name)
                .NotEmpty();

            RuleFor(x => x.OrderOverPrice)
                .NotEmpty()
                .GreaterThanOrEqualTo(x => x.DiscountPrice);

            RuleFor(x => x.RedeemBy)
                .NotEmpty()
                .GreaterThan(DateTime.Today);
        }
    }
}
