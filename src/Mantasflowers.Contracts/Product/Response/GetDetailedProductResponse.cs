using System;
using Mantasflowers.Contracts.Common.Templates;

namespace Mantasflowers.Contracts.Product.Response
{
    public class GetDetailedProductResponse : ProductTemplate
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public string PictureUrl { get; set; }
    }
}