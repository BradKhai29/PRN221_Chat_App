using Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Presentation.Models.Options;
using System.Security.Cryptography;
using System.Text;

namespace Presentation.OptionsSetup
{
    public class JwtBearerOptionsSetup : IConfigureOptions<JwtBearerOptions>
    {
        private readonly JwtOptions _jwtOptions;

        public JwtBearerOptionsSetup(IOptions<JwtOptions> jwtOptions)
        {
            _jwtOptions = jwtOptions.Value;
        }

        public void Configure(JwtBearerOptions options)
        {
            options.TokenValidationParameters = new()
            {
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = _jwtOptions.Issuer,
                ValidAudience = _jwtOptions.Audience,
                IssuerSigningKey = GetSymmetricSecurityKey()
            };
        }

        private SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            var encryptedKey = JwtTokenHelper.GetEncryptedKey(
                privateKey: _jwtOptions.PrivateKey);

            return new SymmetricSecurityKey(key: encryptedKey);
        }
    }
}
