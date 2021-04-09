using System.Collections.Generic;
using Mantasflowers.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Mantasflowers.Contracts.Product.Request
{
    public class GetProductsRequest
    {
        [FromQuery(Name = "page")] // TODO: add [Required] or see if I can configure this with fluent validations
        public int Page { get; set; }

        [FromQuery(Name = "pageSize")] // TODO: same here
        public int PageSize { get; set; }

        [FromQuery(Name = "categories")]
        public IList<ProductCategory> Categories { get; set; } // TODO: same here
    }
}