using FluentValidation;
using Mantasflowers.Contracts.Firebase.Request;

namespace Mantasflowers.WebApi.Validation.Authentication
{
    public class PostUpdatePasswordRequestValidator : AbstractValidator<PostUpdatePasswordRequest>
    {
        public PostUpdatePasswordRequestValidator()
        {
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("'Password' cannot be empty");
        }
    }
}
