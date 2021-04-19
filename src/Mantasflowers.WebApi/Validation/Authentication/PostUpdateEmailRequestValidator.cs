using FluentValidation;
using Mantasflowers.Contracts.Firebase.Request;

namespace Mantasflowers.WebApi.Validation.Authentication
{
    public class PostUpdateEmailRequestValidator : AbstractValidator<PostUpdateEmailRequest>
    {
        public PostUpdateEmailRequestValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty();
        }
    }
}
