using FluentValidation;
using Mantasflowers.Contracts.Order.Request;

namespace Mantasflowers.WebApi.Validation.Order
{
    public class PostOrderAddressRequestValidator : AbstractValidator<PostOrderAddressRequest>
    {
        public PostOrderAddressRequestValidator()
        {
            RuleFor(x => x.City)
                .NotEmpty();

            RuleFor(x => x.Country)
                .NotEmpty();

            RuleFor(x => x.Street)
                .NotEmpty();

            RuleFor(x => x.Zipcode)
                .NotEmpty();
        }
    }
}
