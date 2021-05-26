using Newtonsoft.Json;
using System.Collections.Generic;

namespace Mantasflowers.Contracts.ServiceAgents.MultiParcels.Request
{
    public class CreateShipmentRequest
    {
        [JsonProperty("identifier")]
        public string Identifier { get; set; }

        [JsonProperty("sender")]
        public SenderRequest Sender { get; set; }

        [JsonProperty("receiver")]
        public ReceiverRequest Receiver { get; set; }

        [JsonProperty("pickup")]
        public PickupRequest Pickup { get; set; }

        [JsonProperty("delivery")]
        public DeliveryRequest Delivery { get; set; }

        [JsonProperty("services")]
        public IList<ServiceRequest> Services { get; set; }
    }
}
