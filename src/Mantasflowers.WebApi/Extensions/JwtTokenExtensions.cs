using Mantasflowers.Services.ServiceAgents.Exceptions;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace Mantasflowers.WebApi.Extensions
{
    public static class JwtTokenExtensions
    {
        public static string GetUidFromJwt(this ClaimsPrincipal claimsPrincipal)
        {
            if (claimsPrincipal?.Identity == null)
            {
                throw new InvalidOperationException("JWT Token not found");
            }

            if (!claimsPrincipal.Identity.IsAuthenticated)
            {
                throw new InvalidOperationException("No valid JWT token to extract information from");
            }

            string uid = claimsPrincipal.Claims.SingleOrDefault(claim => claim.Type == "user_id")?.Value;

            if (string.IsNullOrWhiteSpace(uid))
            {
                // Attempt to get uid from different JWT header
                uid = claimsPrincipal.Claims.SingleOrDefault(
                    claim => claim.Type == JwtRegisteredClaimNames.Sub)?.Value;
            }

            if (string.IsNullOrWhiteSpace(uid))
            {
                throw new FirebaseTokenException("Could not extract uid from JWT token");
            }

            return uid;
        }

        public static (string Email, bool IsEmailVerified) GetEmailInfoFromJwt(this ClaimsPrincipal claimsPrincipal)
        {
            if (claimsPrincipal?.Identity == null)
            {
                throw new InvalidOperationException("JWT Token not found");
            }

            if (!claimsPrincipal.Identity.IsAuthenticated)
            {
                throw new InvalidOperationException("No valid JWT token to extract information from");
            }

            var email = claimsPrincipal.Claims.SingleOrDefault(claim => claim.Type == ClaimTypes.Email)?.Value;
            
            if (!bool.TryParse(claimsPrincipal.Claims.SingleOrDefault(claim => claim.Type == "email_verified")?.Value, out bool isVerified)
                || string.IsNullOrWhiteSpace(email))
            {
                throw new FirebaseTokenException("Could not extract email information from JWT token");
            }

            return (email, isVerified);
        }
    }
}
