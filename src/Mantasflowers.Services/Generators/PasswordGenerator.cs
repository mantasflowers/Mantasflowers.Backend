using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using shortid;
using shortid.Configuration;
using System;

namespace Mantasflowers.Services.Generators
{
    public static class PasswordGenerator
    {
        public static (string, string) HashUniquePassword(
            bool useNumbers = true,
            bool useSpecialCharacters = false,
            int length = 9
            )
        {
            string uniquePassword = GenerateUniquePassword(
                useNumbers, useSpecialCharacters, length
                );

            string passwordHash = GeneratePasswordhash(uniquePassword);

            return (uniquePassword, passwordHash);
        }

        public static string GetUniquePasswordHash(string uniquePassword)
        {
            string passwordHash = GeneratePasswordhash(uniquePassword);

            return passwordHash;
        }

        private static string GenerateUniquePassword(
            bool useNumbers,
            bool useSpecialCharacters,
            int length
            )
        {
            var options = new GenerationOptions
            {
                UseNumbers = useNumbers,
                UseSpecialCharacters = useSpecialCharacters,
                Length = length
            };
            string uniquePassword = ShortId.Generate(options);

            return uniquePassword;
        }

        private static string GeneratePasswordhash(string uniquePassword)
        {
            string passwordHash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: uniquePassword,
                salt: new byte[] { 0x00 },
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return passwordHash;
        }
    }
}
