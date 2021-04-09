using FirebaseAdmin.Auth;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mantasflowers.Persistence.Authentication
{
    public sealed class FirebaseContext
    {
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
    }
}
