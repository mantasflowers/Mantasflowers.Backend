using FluentValidation;
using Mantasflowers.Contracts.Firebase.Request;

namespace Mantasflowers.WebApi.Validation.Authentication
{
    public class PostCredentialsRequestValidator : AbstractValidator<PostCredentialsRequest>
    {
        public PostCredentialsRequestValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty();
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("'Password' cannot be empty");
        }
    }
}
