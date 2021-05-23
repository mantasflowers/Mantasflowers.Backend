using System;

namespace Mantasflowers.Contracts.Shipment.Response
{
    public class GetTrackingEventResponse
    {
        public string ShipmentId { get; set; }

        public DateTime Time { get; set; }

        public string Status { get; set; }

        public string Location { get; set; }

        public string CarrierMessage { get; set; }

        public string CarrierReference { get; set; }

        public string CarrierUrl { get; set; }
    }
}
