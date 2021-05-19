using Mantasflowers.Contracts.Common.Templates;

namespace Mantasflowers.Contracts.Order.Response
{
    public class GetOrderItemResponse : OrderItemTemplate
    {
        public string Name { get; set; }

        public string ThumbnailPictureUrl { get; set; }
    }
}
