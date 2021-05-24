namespace Mantasflowers.Contracts.Shipment.Response
{
    public class CancelShipmentResponse
    {
        public string ShipmentId { get; set; }

        public bool ShipmentCancelled { get; set; }
    }
}
