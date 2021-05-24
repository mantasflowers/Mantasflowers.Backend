using System.Collections.Generic;

namespace Mantasflowers.Contracts.Shipment.Response
{
    public class GetTrackingEventsResponse
    {
        public IList<GetTrackingEventResponse> TrackingEvents { get; set; }
    }
}
