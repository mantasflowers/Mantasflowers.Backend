using AutoMapper;
using ServiceAgentRequest = Mantasflowers.Contracts.ServiceAgents.ParcelMonkey.Request;
using ServiceAgentResponse = Mantasflowers.Contracts.ServiceAgents.ParcelMonkey.Response;
using Mantasflowers.Contracts.Shipment.Request;
using Mantasflowers.Contracts.Shipment.Response;

namespace Mantasflowers.WebApi.Setup.Mapping
{
    public class ParcelMonkeyServiceAgentProfile : Profile
    {
        public ParcelMonkeyServiceAgentProfile()
        {
            CreateMap<BoxRequest, ServiceAgentRequest.BoxRequest>();
            CreateMap<RecipientRequest, ServiceAgentRequest.RecipientRequest>();
            CreateMap<SenderRequest, ServiceAgentRequest.SenderRequest>();
            CreateMap<CancelShipmentRequest, ServiceAgentRequest.CancelShipmentRequest>();
            CreateMap<ItemRequest, ServiceAgentRequest.ItemRequest>();
            CreateMap<CustomsRequest, ServiceAgentRequest.CustomsRequest>();
            CreateMap<CreateShipmentRequest, ServiceAgentRequest.CreateShipmentRequest>();
            CreateMap<GetQuotesRequest, ServiceAgentRequest.GetQuotesRequest>();
            CreateMap<GetTrackingEventsRequest, ServiceAgentRequest.GetTrackingEventsRequest>();
            CreateMap<ServiceAgentResponse.CancelShipmentResponse, CancelShipmentResponse>();
            CreateMap<ServiceAgentResponse.CreateShipmentResponse, CreateShipmentResponse>();
            CreateMap<ServiceAgentResponse.GetPaymentLinkResponse, GetPaymentLinkResponse>();
            CreateMap<ServiceAgentResponse.GetQuoteResponse, GetQuoteResponse>();
            CreateMap<ServiceAgentResponse.GetQuotesResponse, GetQuotesResponse>();
            CreateMap<ServiceAgentResponse.GetTrackingEventResponse, GetTrackingEventResponse>();
            CreateMap<ServiceAgentResponse.GetTrackingEventsResponse, GetTrackingEventsResponse>();
        }
    }
}
