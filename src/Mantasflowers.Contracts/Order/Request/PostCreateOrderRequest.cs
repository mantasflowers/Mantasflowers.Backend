using System.Collections.Generic;

namespace Mantasflowers.Contracts.Order.Request
{
    public class PostCreateOrderRequest
    {
        public PostOrderAddressRequest Address { get; set; }

        public PostOrderContactDetailsRequest ContactDetails { get; set; }

        public string Message { get; set; }

        public ShipmentRequest Shipment { get; set; }

        public IList<PostOrderItemRequest> OrderItems { get; set; }
    }
}
