using FluentValidation;
using Mantasflowers.Contracts.User.Request;

namespace Mantasflowers.WebApi.Validation.User
{
    public class PostCreateUserRequestValidator : AbstractValidator<PostCreateUserRequest>
    {
        public PostCreateUserRequestValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty();

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("'Password' cannot be empty");
        }
    }
}
