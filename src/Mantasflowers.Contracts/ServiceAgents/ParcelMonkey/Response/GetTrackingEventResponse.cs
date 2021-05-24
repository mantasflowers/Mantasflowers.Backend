using Newtonsoft.Json;
using System;

namespace Mantasflowers.Contracts.ServiceAgents.ParcelMonkey.Response
{
    public class GetTrackingEventResponse
    {
        [JsonProperty("ShipmentId")]
        public string ShipmentId { get; set; }

        [JsonProperty("time")]
        public DateTime Time { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("carrier_message")]
        public string CarrierMessage { get; set; }

        [JsonProperty("carrier_reference")]
        public string CarrierReference { get; set; }

        [JsonProperty("carrier_url")]
        public string CarrierUrl { get; set; }
    }
}
