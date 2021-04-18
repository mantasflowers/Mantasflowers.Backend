using System.Collections.Generic;
using Mantasflowers.Contracts.Product.Enums;
using Mantasflowers.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Mantasflowers.Contracts.Product.Request
{
    public class GetProductsRequest
    {
        [FromQuery(Name = "page")]
        public int Page { get; set; }

        [FromQuery(Name = "pageSize")]
        public int PageSize { get; set; }

        [FromQuery(Name = "orderBy")]
        public ProductOrderByOptions OrderBy { get; set; } = ProductOrderByOptions.NAME;

        [FromQuery(Name = "orderDescending")]
        public bool OrderDescending { get; set; } = false;

        [FromQuery(Name = "categories")]
        public IList<ProductCategory> Categories { get; set; }
    }
}