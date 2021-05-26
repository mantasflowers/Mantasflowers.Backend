using System.Collections.Generic;

namespace Mantasflowers.Contracts.Shipment.Response
{
    public class MetaResponse
    {
        public IList<string> Include { get; set; }

        public IList<string> Custom { get; set; }
    }
}
