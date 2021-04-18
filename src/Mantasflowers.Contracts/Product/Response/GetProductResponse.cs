using System;
using Mantasflowers.Domain.Enums;

namespace Mantasflowers.Contracts.Product.Response
{
    public class GetProductResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public ProductCategory Category { get; set; }

        public string ShortDescription { get; set; }

        public string ThumbnailPictureUrl { get; set; }

        public decimal Price { get; set; }

        public int LeftInStock { get; set; }

        public decimal? DiscountPercent { get; set; }
    }
}