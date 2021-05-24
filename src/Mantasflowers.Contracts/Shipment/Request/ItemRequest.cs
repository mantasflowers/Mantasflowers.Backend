namespace Mantasflowers.Contracts.Shipment.Request
{
    public class ItemRequest
    {
        public int Quantity { get; set; }

        public string Description { get; set; }

        public decimal ValuePerUnit { get; set; }
    }
}
