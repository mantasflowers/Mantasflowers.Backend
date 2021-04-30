using FirebaseAdmin.Auth;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mantasflowers.Contracts.Firebase.Response;
using Mantasflowers.Contracts.Firebase.Request;
using Mantasflowers.Services.ServiceAgents;
using AutoMapper;
using Mantasflowers.Contracts.ServiceAgents.Firebase.Request;

namespace Mantasflowers.Services.FirebaseService
{
    public sealed class FirebaseService
    {
        private readonly IFirebaseServiceAgent _firebaseServiceAgent;
        private readonly IMapper _mapper;


        public FirebaseService(IFirebaseServiceAgent firebaseServiceAgent, IMapper mapper)
        {
            _firebaseServiceAgent = firebaseServiceAgent;
            _mapper = mapper;
        }

        public async Task<PostTokensResponse> GetTokensAsync(PostCredentialsRequest postCredentialsRequest)
        {
            var firebaseSignInRequest = _mapper.Map<PostSignInRequest>(postCredentialsRequest);
            var firebaseSignInResponse = await _firebaseServiceAgent.PostSignInAsync(firebaseSignInRequest);
            var response = _mapper.Map<PostTokensResponse>(firebaseSignInResponse);

            return response;
        }

        public async Task<PostTokensResponse> RefreshIdTokenAsync(PostRefreshTokenRequest request)
        {
            var firebaseTokenRefreshRequest = _mapper.Map<PostRefreshIdTokenRequest>(request);
            var firebaseTokenRefreshResponse = await _firebaseServiceAgent.PostTokenRefreshAsync(firebaseTokenRefreshRequest);
            var response = _mapper.Map<PostTokensResponse>(firebaseTokenRefreshResponse);

            return response;
        }

        public Task SetCustomUserClaimsAsync(string uid, Dictionary<string, object> claims)
        {
            return FirebaseAuth.DefaultInstance.SetCustomUserClaimsAsync(uid, claims);
        }

        /// <summary>
        /// Only meant to verify ID tokens that come from the client SDKs, not the custom tokens
        /// </summary>
        /// <param name="idToken"></param>
        /// <returns></returns>
        public Task<FirebaseToken> VerifyIdTokenAsync(string idToken)
        {
            return FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(idToken);
        }

        public Task<UserRecord> CreateUserAsync(string email, string password)
        {
            var args = new UserRecordArgs()
            {
                Email = email,
                EmailVerified = false,
                Password = password,
                Disabled = false
            };

            return FirebaseAuth.DefaultInstance.CreateUserAsync(args);
        }

        public Task<UserRecord> GetUserByUidAsync(string uid)
        {
            return FirebaseAuth.DefaultInstance.GetUserAsync(uid);
        }

        public Task<UserRecord> GetUserByEmailAsync(string email)
        {
            return FirebaseAuth.DefaultInstance.GetUserByEmailAsync(email);
        }

        private Task<UserRecord> UpdateUserAsync(UserRecordArgs args)
        {
            return FirebaseAuth.DefaultInstance.UpdateUserAsync(args);
        }

        public Task<UserRecord> UpdateUserEmailAsync(string uid, string email)
        {
            return UpdateUserAsync(new UserRecordArgs
            {
                Uid = uid,
                Email = email
            });
        }

        public Task<UserRecord> UpdateUserPasswordAsync(string uid, string password)
        {
            return UpdateUserAsync(new UserRecordArgs
            {
                Uid = uid,
                Password = password
            });
        }

        public Task DeleteUserByUidAsync(string uid)
        {
            return FirebaseAuth.DefaultInstance.DeleteUserAsync(uid);
        }

        public Task RevokeRefreshTokenAsync(string uid)
        {
            return FirebaseAuth.DefaultInstance.RevokeRefreshTokensAsync(uid);
        }
    }
}
