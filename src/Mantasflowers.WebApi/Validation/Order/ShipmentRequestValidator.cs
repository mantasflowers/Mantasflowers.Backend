using FluentValidation;
using Mantasflowers.Contracts.Order.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mantasflowers.WebApi.Validation.Order
{
    public class ShipmentRequestValidator : AbstractValidator<ShipmentRequest>
    {
        public ShipmentRequestValidator()
        {
            RuleFor(x => x.Uid)
                .NotEmpty();
        }
    }
}
