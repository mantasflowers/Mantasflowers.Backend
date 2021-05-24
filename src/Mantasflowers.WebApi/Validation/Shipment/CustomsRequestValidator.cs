using FluentValidation;
using Mantasflowers.Contracts.Shipment.Request;
using System.Collections.Generic;

namespace Mantasflowers.WebApi.Validation.Shipment
{
    public class CustomsRequestValidator : AbstractValidator<CustomsRequest>
    {
        private readonly IList<string> DocTypeValues = 
            new List<string>() { "proforma", "commercial" };
        private readonly IList<string> ReasonValues =
            new List<string>() { "Sold", "Gift", "Sample", 
                "Repair", "Documents", "Intra Company Transfer", 
                "Temporary Export", "Return", "Personal Effects" };


        public CustomsRequestValidator()
        {
            RuleFor(x => x.DocType)
                .NotNull()
                .Must(x => DocTypeValues.Contains(x))
                .WithMessage("Allowed DocType values: " + string.Join(",", DocTypeValues));

            RuleFor(x => x.Reason)
                .NotNull()
                .Must(x => ReasonValues.Contains(x))
                .WithMessage("Allowed Reason values: " + string.Join(",", ReasonValues));

            RuleFor(x => x.SenderName)
                .NotNull();

            RuleFor(x => x.SenderTaxReference)
                .NotNull();

            RuleFor(x => x.RecipientName)
                .NotNull();

            RuleFor(x => x.RecipientTaxReference)
                .NotNull();

            RuleFor(x => x.CountryOfManufacture)
                .NotNull();

            RuleForEach(x => x.Items)
                .NotNull()
                .SetValidator(new ItemRequestValidator());
        }
    }
}
