using AutoMapper;
using ServiceAgent = Mantasflowers.Contracts.ServiceAgents.MultiParcels.Request;
using Mantasflowers.Contracts.Shipment.Request;
using System.Threading.Tasks;
using Mantasflowers.Contracts.Shipment.Response;
using Mantasflowers.Services.ServiceAgents.MultiParcels;

namespace Mantasflowers.Services.Services.Shipment
{
    public class ShipmentService : IShipmentService
    {
        private readonly IMultiParcelServiceAgent _mpServiceAgent;
        private readonly IMapper _mapper;

        public ShipmentService(
            IMultiParcelServiceAgent mpServiceAgent,
            IMapper mapper)
        {
            _mpServiceAgent = mpServiceAgent;
            _mapper = mapper;
        }

        public async Task<CreateShipmentResponse> CreateShipment(CreateShipmentRequest request)
        {
            var createShipmentRequest = _mapper.Map<ServiceAgent.CreateShipmentRequest>(request);
            var createShipmentResponse = await _mpServiceAgent.CreateShipment(createShipmentRequest);
            var response = _mapper.Map<CreateShipmentResponse>(createShipmentResponse);

            return response;
        }
    }
}
