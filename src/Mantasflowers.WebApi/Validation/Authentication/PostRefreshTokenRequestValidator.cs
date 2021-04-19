using FluentValidation;
using Mantasflowers.Contracts.Firebase.Request;

namespace Mantasflowers.WebApi.Validation.Authentication
{
    public class PostRefreshTokenRequestValidator : AbstractValidator<PostRefreshTokenRequest>
    {
        public PostRefreshTokenRequestValidator()
        {
            RuleFor(x => x.RefreshToken)
                .NotEmpty();
        }
    }
}
