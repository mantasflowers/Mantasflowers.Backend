using FluentValidation;
using Mantasflowers.Contracts.Feedback;

namespace Mantasflowers.WebApi.Validation.Feedback
{
    public class FeedbackValidator : AbstractValidator<CreateFeedbackRequest>
    {
        public FeedbackValidator()
        {
            RuleFor(x => x.Name)
                .MaximumLength(200);

            RuleFor(x => x.Email)
                .MaximumLength(320);

            RuleFor(x => x.Text)
                .NotEmpty()
                .MaximumLength(500);
        }
    }
}