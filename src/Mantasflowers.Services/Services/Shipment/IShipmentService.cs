using Mantasflowers.Contracts.Shipment.Request;
using Mantasflowers.Contracts.Shipment.Response;
using System.Threading.Tasks;

namespace Mantasflowers.Services.Services.Shipment
{
    public interface IShipmentService
    {
        Task<GetQuotesResponse> GetQuotes(GetQuotesRequest request);

        Task<CreateShipmentResponse> CreateShipment(CreateShipmentRequest request);

        Task<CancelShipmentResponse> CancelShipment(CancelShipmentRequest request);

        Task<GetTrackingEventsResponse> GetTrackingEvents(GetTrackingEventsRequest request);

        Task<GetPaymentLinkResponse> GetPaymentLink(GetPaymentLinkRequest request);
    }
}
