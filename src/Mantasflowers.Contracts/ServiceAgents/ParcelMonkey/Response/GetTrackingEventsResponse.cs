using System.Collections.Generic;

namespace Mantasflowers.Contracts.ServiceAgents.ParcelMonkey.Response
{
    public class GetTrackingEventsResponse
    {
        public IList<GetTrackingEventResponse> TrackingEvents { get; set; }
    }
}
