using Mantasflowers.Services.ServiceAgents.Extensions;
using Mantasflowers.Contracts.ServiceAgents.ParcelMonkey.Request;
using Mantasflowers.Contracts.ServiceAgents.ParcelMonkey.Response;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Mantasflowers.Services.ServiceAgents.Exceptions;

namespace Mantasflowers.Services.ServiceAgents.ParcelMonkey
{
    public class ParcelMonkeyServiceAgent : IParcelMonkeyServiceAgent
    {
        private readonly IHttpClientFactory _clientFactory;

        public ParcelMonkeyServiceAgent(
            IHttpClientFactory clientFactory
            )
        {
            _clientFactory = clientFactory;
        }

        public async Task<GetQuotesResponse> GetQuotes(GetQuotesRequest request)
        {
            try
            {
                using var client = _clientFactory.CreateClient("ParcelMonkey");

                var agentResponse = new GetQuotesResponse
                {
                    Quotes = await client.PostAsync<IList<GetQuoteResponse>>("GetQuote", request)
                };

                return agentResponse;
            }
            catch (HttpRequestException ex)
            {
                throw new ParcelMonkeyException(ex.Message);
            }
        }

        public async Task<CreateShipmentResponse> CreateShipment(CreateShipmentRequest request)
        {
            try
            {
                using var client = _clientFactory.CreateClient("ParcelMonkey");

                var agentResponse = await client.PostAsync<CreateShipmentResponse>("CreateShipment", request);

                return agentResponse;
            }
            catch (HttpRequestException ex)
            {
                throw new ParcelMonkeyException(ex.Message);
            }
        }

        public async Task<CancelShipmentResponse> CancelShipment(CancelShipmentRequest request)
        {
            try
            {
                using var client = _clientFactory.CreateClient("ParcelMonkey");

                var agentResponse = await client.PostAsync<CancelShipmentResponse>("CancelShipment", request);

                return agentResponse;
            }
            catch (HttpRequestException ex)
            {
                throw new ParcelMonkeyException(ex.Message);
            }
        }

        public async Task<GetTrackingEventsResponse> GetTrackingEvents(GetTrackingEventsRequest request)
        {
            try
            {
                using var client = _clientFactory.CreateClient("ParcelMonkey");

                var agentResponse = new GetTrackingEventsResponse
                {
                    TrackingEvents = await client.PostAsync<IList<GetTrackingEventResponse>>("GetTrackingEvents", request)
                };

                return agentResponse;
            }
            catch (HttpRequestException ex)
            {
                throw new ParcelMonkeyException(ex.Message);
            }
        }
    }
}
