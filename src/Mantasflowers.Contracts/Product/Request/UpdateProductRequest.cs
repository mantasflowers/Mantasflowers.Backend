using Mantasflowers.Contracts.Common.Templates;

namespace Mantasflowers.Contracts.Product.Request
{
    public class UpdateProductRequest : ProductTemplate
    {
        public UpdateProductInfoRequest ProductInfo { get; set; }
    }
}