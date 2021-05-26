namespace Mantasflowers.Contracts.Shipment.Request
{
    public class ServiceRequest
    {
        public int Enabled { get; set; }

        public string Code { get; set; }

        public decimal Value { get; set; }

        public string Currency { get; set; }
    }
}
