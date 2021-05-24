using AutoMapper;
using ServiceAgent = Mantasflowers.Contracts.ServiceAgents.ParcelMonkey.Request;
using Mantasflowers.Contracts.Shipment.Request;
using Mantasflowers.Services.ServiceAgents.ParcelMonkey;
using System.Threading.Tasks;
using Mantasflowers.Contracts.Shipment.Response;

namespace Mantasflowers.Services.Services.Shipment
{
    public class ShipmentService : IShipmentService
    {
        private readonly IParcelMonkeyServiceAgent _pmServiceAgent;
        private readonly IMapper _mapper;

        public ShipmentService(IParcelMonkeyServiceAgent pmServiceAgent, IMapper mapper)
        {
            _pmServiceAgent = pmServiceAgent;
            _mapper = mapper;
        }

        public async Task<GetQuotesResponse> GetQuotes(GetQuotesRequest request)
        {
            var getQuotesRequest = _mapper.Map<ServiceAgent.GetQuotesRequest>(request);
            var getQuotesResponse = await _pmServiceAgent.GetQuotes(getQuotesRequest);
            var response = _mapper.Map<GetQuotesResponse>(getQuotesResponse);

            return response;
        }

        public async Task<CreateShipmentResponse> CreateShipment(CreateShipmentRequest request)
        {
            var createShipmentRequest = _mapper.Map<ServiceAgent.CreateShipmentRequest>(request);
            var createShipmentResponse = await _pmServiceAgent.CreateShipment(createShipmentRequest);
            var response = _mapper.Map<CreateShipmentResponse>(createShipmentResponse);

            return response;
        }

        public async Task<CancelShipmentResponse> CancelShipment(CancelShipmentRequest request)
        {
            var cancelShipmentRequest = _mapper.Map<ServiceAgent.CancelShipmentRequest>(request);
            var cancelShipmentResponse = await _pmServiceAgent.CancelShipment(cancelShipmentRequest);
            var response = _mapper.Map<CancelShipmentResponse>(cancelShipmentResponse);

            return response;
        }

        public async Task<GetTrackingEventsResponse> GetTrackingEvents(GetTrackingEventsRequest request)
        {
            var getTrackingEventsRequest = _mapper.Map<ServiceAgent.GetTrackingEventsRequest>(request);
            var getTrackingEventsResponse = await _pmServiceAgent.GetTrackingEvents(getTrackingEventsRequest);
            var response = _mapper.Map<GetTrackingEventsResponse>(getTrackingEventsResponse);

            return response;
        }

        public async Task<GetPaymentLinkResponse> GetPaymentLink(GetPaymentLinkRequest request)
        {
            var getPaymentLinkRequest = _mapper.Map<ServiceAgent.GetPaymentLinkRequest>(request.ShipmentIds);
            var getPaymentLinkResponse = await _pmServiceAgent.GetPaymentLink(getPaymentLinkRequest);
            var response = _mapper.Map<GetPaymentLinkResponse>(getPaymentLinkResponse);

            return response;
        }
    }
}
