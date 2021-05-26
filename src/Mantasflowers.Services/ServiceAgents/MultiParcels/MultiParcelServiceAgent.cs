using Mantasflowers.Services.ServiceAgents.Extensions;
using Mantasflowers.Contracts.ServiceAgents.MultiParcels.Request;
using Mantasflowers.Contracts.ServiceAgents.MultiParcels.Response;
using System.Net.Http;
using System.Threading.Tasks;
using Mantasflowers.Services.ServiceAgents.Exceptions;

namespace Mantasflowers.Services.ServiceAgents.MultiParcels
{
    public class MultiParcelServiceAgent : IMultiParcelServiceAgent
    {
        private readonly IHttpClientFactory _clientFactory;

        public MultiParcelServiceAgent(
            IHttpClientFactory clientFactory
            )
        {
            _clientFactory = clientFactory;
        }

        public async Task<CreateShipmentResponse> CreateShipment(CreateShipmentRequest request)
        {
            try
            {
                using var client = _clientFactory.CreateClient("MultiParcel");

                var agentResponse = await client.PostAsync<CreateShipmentResponse>("shipments", request);

                return agentResponse;
            }
            catch (HttpRequestException ex)
            {
                throw new MultiParcelException(ex.Message);
            }
        }
    }
}
