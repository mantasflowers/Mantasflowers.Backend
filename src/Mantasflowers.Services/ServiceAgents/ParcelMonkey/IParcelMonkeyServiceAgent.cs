using Mantasflowers.Contracts.ServiceAgents.ParcelMonkey.Request;
using Mantasflowers.Contracts.ServiceAgents.ParcelMonkey.Response;
using System.Threading.Tasks;

namespace Mantasflowers.Services.ServiceAgents.ParcelMonkey
{
    public interface IParcelMonkeyServiceAgent
    {
        Task<GetQuotesResponse> GetQuotes(GetQuotesRequest request);

        Task<CreateShipmentResponse> CreateShipment(CreateShipmentRequest request);

        Task<CancelShipmentResponse> CancelShipment(CancelShipmentRequest request);

        Task<GetTrackingEventsResponse> GetTrackingEvents(GetTrackingEventsRequest request);
    }
}
