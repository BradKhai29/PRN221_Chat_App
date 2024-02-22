using BusinessLogic.Services.Externals.Base;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Options.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BusinessLogic.Services.Externals.Implementations
{
    internal class AccessTokenHandlingService :
        IAccessTokenHandlingService
    {
        private readonly JwtOptions _jwtOptions;
        private readonly SecurityTokenHandler _securityTokenHandler;

        public AccessTokenHandlingService(
            IOptions<JwtOptions> jwtOptions,
            SecurityTokenHandler securityTokenHandler)
        {
            _jwtOptions = jwtOptions.Value;
            _securityTokenHandler = securityTokenHandler;
        }

        public string GenerateJwtToken(
            IEnumerable<Claim> claims,
            TimeSpan liveSpan)
        {
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _jwtOptions.Issuer,
                Audience = _jwtOptions.Audience,
                Subject = new ClaimsIdentity(claims: claims),
                SigningCredentials = new SigningCredentials(
                    key: _jwtOptions.GetSecurityKey(),
                    algorithm: SecurityAlgorithms.HmacSha256),
                Expires = DateTime.UtcNow.Add(liveSpan)
            };

            // Generate token.
            var token = _securityTokenHandler.CreateToken(tokenDescriptor: tokenDescriptor);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
