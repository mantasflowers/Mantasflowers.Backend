using FluentValidation;
using Mantasflowers.Contracts.Firebase.Request;

namespace Mantasflowers.WebApi.Validation.Authentication
{
    public class PostRoleRequestValidator : AbstractValidator<PostRoleRequest>
    {
        public PostRoleRequestValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty();
            RuleFor(x => x.Role)
                .NotEmpty();
        }
    }
}
