using FluentValidation;
using Mantasflowers.Contracts.User.Request;

namespace Mantasflowers.WebApi.Validation.User
{
    public class UpdateUserRequestValidator : AbstractValidator<UpdateUserRequest>
    {
        public UpdateUserRequestValidator()
        {
            RuleFor(x => x.FirstName)
                .MaximumLength(200);

            RuleFor(x => x.LastName)
                .MaximumLength(200);
            
            When(x => x.Address != null, () =>
            {
                RuleFor(x => x.Address.Country)
                    .MaximumLength(100);

                RuleFor(x => x.Address.City)
                    .MaximumLength(100);

                RuleFor(x => x.Address.Street)
                    .MaximumLength(100);

                RuleFor(x => x.Address.Zipcode)
                    .MaximumLength(20);
            });

            When(x => x.UserContactInfo != null, () =>
            {
                RuleFor(x => x.UserContactInfo.Email)
                    .MaximumLength(320);

                RuleFor(x => x.UserContactInfo.Phone)
                    .MaximumLength(20);
            });
        }
    }
}