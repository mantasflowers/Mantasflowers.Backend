using Mantasflowers.Contracts.ServiceAgents.MultiParcels.Request;
using Mantasflowers.Contracts.ServiceAgents.MultiParcels.Response;
using System.Threading.Tasks;

namespace Mantasflowers.Services.ServiceAgents.MultiParcels
{
    public interface IMultiParcelServiceAgent
    {
        Task<CreateShipmentResponse> CreateShipment(CreateShipmentRequest request);
    }
}
