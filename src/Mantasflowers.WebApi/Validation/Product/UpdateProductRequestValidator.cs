using FluentValidation;
using Mantasflowers.Contracts.Product.Request;

namespace Mantasflowers.WebApi.Validation.Product
{
    public class UpdateProductRequestValidator : AbstractValidator<UpdateProductRequest>
    {
        public UpdateProductRequestValidator()
        {
            RuleFor(x => x.Name)
                .MaximumLength(100)
                .NotEmpty();

            RuleFor(x => x.Category)
                .NotNull();

            RuleFor(x => x.ShortDescription)
                .MaximumLength(2000);

            RuleFor(x => x.Price)
                .GreaterThan(0)
                .NotNull();

            RuleFor(x => x.LeftInStock)
                .GreaterThanOrEqualTo(0)
                .NotNull();

            RuleFor(x => x.DiscountPercent)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.ThumbnailPictureUrl)
                .MaximumLength(2000);

            RuleFor(x => x.ProductInfo)
                .NotNull();

            When(x => x.ProductInfo != null, () =>
            {
                RuleFor(x => x.ProductInfo.Description)
                    .MaximumLength(2000);

                RuleFor(x => x.ProductInfo.PictureUrl)
                    .MaximumLength(2000);
            });
        }
    }
}