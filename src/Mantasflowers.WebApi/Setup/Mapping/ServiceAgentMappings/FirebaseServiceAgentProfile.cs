using AutoMapper;
using FirebaseAdmin.Auth;
using Mantasflowers.Contracts.Firebase.Request;
using Mantasflowers.Contracts.Firebase.Response;
using Mantasflowers.Contracts.ServiceAgents.Firebase.Request;
using Mantasflowers.Contracts.ServiceAgents.Firebase.Response;

namespace Mantasflowers.WebApi.Setup.Mapping.ServiceAgentMappings
{
    public class FirebaseServiceAgentProfile : Profile
    {
        public FirebaseServiceAgentProfile()
        {
            CreateMap<PostCredentialsRequest, PostSignInRequest>();
            CreateMap<PostSignInResponse, PostTokensResponse>();
            CreateMap<PostRefreshTokenRequest, PostRefreshIdTokenRequest>();
            CreateMap<PostRefreshIdTokenResponse, PostTokensResponse>();
        }
    }
}
