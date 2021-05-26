namespace Mantasflowers.Contracts.Shipment.Response
{
    public class DataResponse
    {
        public string Object { get; set; }

        public string Id { get; set; }

        public string Identifier { get; set; }

        public int Confirmed { get; set; }

        public int Manifest { get; set; }

        public string PickupTypeCode { get; set; }

        public string DeliveryTypeCode { get; set; }

        public string CourierCode { get; set; }

        public string Method { get; set; }

        public int Packages { get; set; }

        public int Weight { get; set; }

        public CreatedAtResponse CreatedAt { get; set; }

        public CreatedAtResponse UpdatedAt { get; set; }
    }
}
