﻿using Newtonsoft.Json;

namespace Mantasflowers.Contracts.ServiceAgents.ParcelMonkey.Request
{
    public class CancelShipmentRequest
    {
        [JsonProperty("ShipmentId")]
        public string Shipmentid { get; set; }
    }
}
