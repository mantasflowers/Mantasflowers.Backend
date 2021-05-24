namespace Mantasflowers.Contracts.Shipment.Response
{
    public class GetQuoteResponse
    {
        public string Service { get; set; }

        public string Carrier { get; set; }

        public string ServiceName { get; set; }

        public string ServiceDescription { get; set; }

        public bool CustomsInvoiceRequired { get; set; }

        public decimal ShippingPriceNet { get; set; }

        public decimal ProtectionPriceNet { get; set; }

        public decimal TotalPriceNet { get; set; }

        public decimal TotalPriceGross { get; set; }
    }
}
