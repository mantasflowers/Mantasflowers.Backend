using Newtonsoft.Json;

namespace Mantasflowers.Contracts.ServiceAgents.ParcelMonkey.Response
{
    public class GetQuoteResponse
    {
        [JsonProperty("service")]
        public string Service { get; set; }

        [JsonProperty("carrier")]
        public string Carrier { get; set; }

        [JsonProperty("service_name")]
        public string ServiceName { get; set; }

        [JsonProperty("service_description")]
        public string ServiceDescription { get; set; }

        [JsonProperty("customs_invoice_required")]
        public bool CustomsInvoiceRequired { get; set; }

        [JsonProperty("shipping_price_net")]
        public decimal ShippingPriceNet { get; set; }

        [JsonProperty("protection_price_net")]
        public decimal ProtectionPriceNet { get; set; }

        [JsonProperty("total_price_net")]
        public decimal TotalPriceNet { get; set; }

        [JsonProperty("total_price_gross")]
        public decimal TotalPriceGross { get; set; }
    }
}
