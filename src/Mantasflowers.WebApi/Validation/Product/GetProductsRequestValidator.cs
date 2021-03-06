using FluentValidation;
using Mantasflowers.Contracts.Product.Request;

namespace Mantasflowers.WebApi.Validation.Product
{
    public class GetProductsRequestValidator : AbstractValidator<GetProductsRequest>
    {
        public GetProductsRequestValidator()
        {
            RuleFor(x => x.Page)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(x => x.PageSize)
                .NotEmpty()
                .GreaterThan(0)
                .LessThanOrEqualTo(200);
        }
    }
}