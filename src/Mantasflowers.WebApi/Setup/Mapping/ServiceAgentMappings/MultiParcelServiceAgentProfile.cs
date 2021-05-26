using AutoMapper;
using Mantasflowers.Contracts.Shipment.Request;
using Mantasflowers.Contracts.Shipment.Response;
using ServiceAgentRequest = Mantasflowers.Contracts.ServiceAgents.MultiParcels.Request;
using ServiceAgentResponse = Mantasflowers.Contracts.ServiceAgents.MultiParcels.Response;

namespace Mantasflowers.WebApi.Setup.Mapping.ServiceAgentMappings
{
    public class MultiParcelServiceAgentProfile : Profile
    {
        public MultiParcelServiceAgentProfile()
        {
            CreateMap<DeliveryRequest, ServiceAgentRequest.DeliveryRequest>();
            CreateMap<PickupRequest, ServiceAgentRequest.PickupRequest>();
            CreateMap<SenderRequest, ServiceAgentRequest.SenderRequest>();
            CreateMap<ReceiverRequest, ServiceAgentRequest.ReceiverRequest>();
            CreateMap<SenderRequest, ServiceAgentRequest.SenderRequest>();
            CreateMap<ServiceRequest, ServiceAgentRequest.ServiceRequest>();
            CreateMap<CreateShipmentRequest, ServiceAgentRequest.CreateShipmentRequest>();
            CreateMap<ServiceAgentResponse.CreatedAtResponse, CreatedAtResponse>();
            CreateMap<ServiceAgentResponse.UpdatedAtResponse, UpdatedAtResponse>();
            CreateMap<ServiceAgentResponse.MetaResponse, MetaResponse>();
            CreateMap<ServiceAgentResponse.DataResponse, DataResponse>();
            CreateMap<ServiceAgentResponse.CreateShipmentResponse, CreateShipmentResponse>();
        }
    }
}
