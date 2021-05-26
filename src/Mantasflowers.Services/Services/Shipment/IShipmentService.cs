using Mantasflowers.Contracts.Shipment.Request;
using Mantasflowers.Contracts.Shipment.Response;
using System.Threading.Tasks;

namespace Mantasflowers.Services.Services.Shipment
{
    public interface IShipmentService
    {
        Task<CreateShipmentResponse> CreateShipment(CreateShipmentRequest request);
    }
}
