using Mantasflowers.Contracts.Common.Templates;

namespace Mantasflowers.Contracts.Product.Request
{
    public class CreateProductRequest : ProductTemplate
    {
        public CreateProductInfoRequest ProductInfo { get; set; }
    }
}