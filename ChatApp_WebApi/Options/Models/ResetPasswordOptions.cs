using Helpers;
using Microsoft.IdentityModel.Tokens;
using Options.Commons.Constants;

namespace Options.Models
{
    public class ResetPasswordOptions
    {
        public const string ParentSectionName = AuthenticationSection.Name;
        public const string SectionName = "ResetPassword";

        public string Issuer { get; set; }

        public string Audience { get; set; }

        public string PrivateKey { get; set; }

        public int LiveMinutes { get; set; }

        #region Get Key
        public byte[] GetKey()
        {
            return JwtTokenHelper.Encrypt(key: PrivateKey);
        }

        public SymmetricSecurityKey GetSecurityKey()
        {
            var encryptedKey = GetKey();

            return new SymmetricSecurityKey(key: encryptedKey);
        }
        #endregion

        public TimeSpan GetLifeSpan()
        {
            return TimeSpan.FromMinutes(value: LiveMinutes);
        }
    }
}
