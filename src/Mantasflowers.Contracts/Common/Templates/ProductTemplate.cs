using System;
using Mantasflowers.Domain.Enums;

namespace Mantasflowers.Contracts.Common.Templates
{
    public class ProductTemplate : VersionableDtoTemplate
    {
        public string Name { get; set; }

        public ProductCategory Category { get; set; }

        public string ShortDescription { get; set; }

        public string ThumbnailPictureUrl { get; set; }

        public decimal Price { get; set; }

        public int LeftInStock { get; set; }

        public decimal? DiscountPercent { get; set; }
    }
}