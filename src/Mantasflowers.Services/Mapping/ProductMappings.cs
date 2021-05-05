using System.Collections.Generic;
using Mantasflowers.Contracts.Product.Enums;
using Mantasflowers.Domain.Entities;

namespace Mantasflowers.Services.Mapping
{
    public static class ProductMappings
    {
        public static readonly Dictionary<ProductOrderByOptions, string> ProductSortingMapping
            = new Dictionary<ProductOrderByOptions, string>
            {
                { ProductOrderByOptions.NAME, nameof(Product.Name) },
                { ProductOrderByOptions.PRICE, nameof(Product.Price) },
                { ProductOrderByOptions.LEFT_IN_STOCK, nameof(Product.LeftInStock) },
                { ProductOrderByOptions.DISCOUNT_PERCENT, nameof(Product.DiscountPercent) },
            };
    }
}