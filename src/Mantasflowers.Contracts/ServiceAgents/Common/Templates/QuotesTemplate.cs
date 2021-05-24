using Mantasflowers.Contracts.ServiceAgents.ParcelMonkey.Request;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Mantasflowers.Contracts.ServiceAgents.Common.Templates
{
    public abstract class QuotesTemplate
    {
        [JsonProperty("origin")]
        public string Origin { get; set; }

        [JsonProperty("destination")]
        public string Destination { get; set; }

        [JsonProperty("goods_value")]
        public decimal GoodsValue { get; set; }

        [JsonProperty("boxes")]
        public IList<BoxRequest> Boxes { get; set; }

        [JsonProperty("sender")]
        public SenderRequest Sender { get; set; }

        [JsonProperty("recipient")]
        public RecipientRequest Recipient { get; set; }
    }
}
