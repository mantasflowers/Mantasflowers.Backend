using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Mantasflowers.Services.ServiceAgents
{
    public static class ServiceAgentExtensions
    {
        public static async Task<TResponse> PostAsync<TResponse>(this HttpClient client, string url, object content)
        {
            var serializedContent = JsonConvert.SerializeObject(content);
            var response = await client.PostAsync(url,
                new StringContent(serializedContent, Encoding.UTF8, "application/json"));

            var responseData = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(responseData);
            }

            return JsonConvert.DeserializeObject<TResponse>(responseData);
        }
    }
}
