using Helpers;
using Microsoft.IdentityModel.Tokens;

namespace Options.Models
{
    public sealed class JwtOptions
    {
        public const string ParentSectionName = "Authentication";
        public const string SectionName = "Jwt";

        public string Issuer { get; set; }

        public string Audience { get; set; }

        public string PrivateKey { get; set; }

        /// <summary>
        ///     The number of days this token will live in short term.
        /// </summary>
        public int DefaultShortLiveDays { get; set; }

        /// <summary>
        ///     The number of days this token will live in long term.
        /// </summary>
        public int DefaultLongLiveDays { get; set; }

        public byte[] GetKey()
        {
            return JwtTokenHelper.Encrypt(key: PrivateKey);
        }

        public SymmetricSecurityKey GetSecurityKey()
        {
            var encryptedKey = GetKey();

            return new SymmetricSecurityKey(key: encryptedKey);
        }
    }
}
