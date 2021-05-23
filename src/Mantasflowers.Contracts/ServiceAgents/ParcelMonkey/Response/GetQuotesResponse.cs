using Newtonsoft.Json;
using System.Collections.Generic;

namespace Mantasflowers.Contracts.ServiceAgents.ParcelMonkey.Response
{
    public class GetQuotesResponse
    {
        public IList<GetQuoteResponse> Quotes { get; set; }
    }
}
