using System.Threading.Tasks;
using Mantasflowers.Contracts.ServiceAgents.Firebase.Request;
using Mantasflowers.Contracts.ServiceAgents.Firebase.Response;

namespace Mantasflowers.Services.ServiceAgents
{
    public interface IFirebaseServiceAgent
    {
        Task<PostSignInResponse> PostSignInAsync(PostSignInRequest request);

        Task<PostRefreshIdTokenResponse> PostTokenRefreshAsync(PostRefreshIdTokenRequest request);
    }
}