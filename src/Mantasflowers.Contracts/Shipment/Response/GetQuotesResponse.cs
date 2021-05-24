using System.Collections.Generic;

namespace Mantasflowers.Contracts.Shipment.Response
{
    public class GetQuotesResponse
    {
        public IList<GetQuoteResponse> Quotes { get; set; }
    }
}
