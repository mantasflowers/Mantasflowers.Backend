using System;
using Mantasflowers.Contracts.Common.Templates;

namespace Mantasflowers.Contracts.Product.Response
{
    public class GetProductResponse : ProductTemplate
    {
        public Guid Id { get; set; }
    }
}