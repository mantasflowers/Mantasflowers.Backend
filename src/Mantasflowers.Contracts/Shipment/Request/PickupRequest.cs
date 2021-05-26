using System.Collections.Generic;

namespace Mantasflowers.Contracts.Shipment.Request
{
    public class PickupRequest
    {
        public string Type { get; set; }

        public int Packages { get; set; }

        public IList<string> PackageSizes { get; set; }

        public decimal Weight { get; set; }
    }
}
