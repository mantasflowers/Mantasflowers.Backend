using FluentValidation;
using Mantasflowers.Contracts.Order.Request;

namespace Mantasflowers.WebApi.Validation.Order
{
    public class GetOrdersRequestValidator : AbstractValidator<GetOrdersRequest>
    {
        public GetOrdersRequestValidator()
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
