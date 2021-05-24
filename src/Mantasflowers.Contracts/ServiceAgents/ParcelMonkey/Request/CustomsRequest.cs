using Newtonsoft.Json;
using System.Collections.Generic;

namespace Mantasflowers.Contracts.ServiceAgents.ParcelMonkey.Request
{
    public class CustomsRequest
    {
        /// <summary>
        /// proforma, commercial
        /// </summary>
        [JsonProperty("doc_type")]
        public string DocType { get; set; }

        /// <summary>
        /// Sold, Gift, Sample, Repair, Documents, Intra Company Transfer, Temporary Export, Return, Personal Effects
        /// </summary>
        [JsonProperty("reason")]
        public string Reason { get; set; }

        /// <summary>
        /// Can be a company name
        /// </summary>
        [JsonProperty("sender_name")]
        public string SenderName { get; set; }

        /// <summary>
        /// "Private Individual" or VAT number
        /// </summary>
        [JsonProperty("sender_tax_reference")]
        public string SenderTaxReference { get; set; }

        /// <summary>
        /// Can be a company name
        /// </summary>
        [JsonProperty("recipient_name")]
        public string RecipientName { get; set; }

        /// <summary>
        /// "Private Individual" or Local Tax Reference
        /// </summary>
        [JsonProperty("recipient_tax_reference")]
        public string RecipientTaxReference { get; set; }

        [JsonProperty("country_of_manufacture")]
        public string CountryOfManufacture { get; set; }

        [JsonProperty("items")]
        public IList<ItemRequest> Items { get; set; }
    }
}
