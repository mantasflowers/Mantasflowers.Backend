using System.Linq;
using FluentValidation;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Mantasflowers.WebApi.Validation
{
    public class ValidateRequestAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                throw new ValidationException(ExtractErrorMessages(context.ModelState));
            }
        }

        private static string ExtractErrorMessages(ModelStateDictionary modelState)
        {
            return string.Join("\n", modelState.Values
                .SelectMany(v => v.Errors)
                .Select(v => v.ErrorMessage));
        }
    }
}