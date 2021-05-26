using System.Collections.Generic;

namespace Mantasflowers.Contracts.Shipment.Request
{
    public class CreateShipmentRequest
    {
        public string Identifier { get; set; }

        public SenderRequest Sender { get; set; }

        public ReceiverRequest Receiver { get; set; }

        public PickupRequest Pickup { get; set; }

        public DeliveryRequest Delivery { get; set; }

        public IList<ServiceRequest> Services { get; set; }
    }
}
