using DataAccess.Commons.SystemConstants;
using DataAccess.Core.Entities;
using DataAccess.Repositories.Base;
using Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Presentation.DTOs.Implementation.Auths.InComings;
using Presentation.Models.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JwtOptions _jwtOptions;
        private readonly IUserRepository _userRepository;

        public AuthController(
            IOptions<JwtOptions> jwtOptions,
            IUserRepository userRepository)
        {
            _jwtOptions = jwtOptions.Value;
            _userRepository = userRepository;
        }

        [HttpPost("system")]
        public async Task<IActionResult> CreateSystemUser()
        {
            var user = new UserEntity
            {
                Id = DefaultValues.SystemId,
                //UserName = "system",
                //PasswordHash = "system",
                //CreatedAt = DateTime.UtcNow,
                //UpdatedAt = DateTime.UtcNow,
                //RemovedAt = DefaultValues.MinDateTime,
                //AvatarUrl = DefaultValues.UserAvatarUrl,
                //Email = "system@mail.com",
                //PhoneNumber = string.Empty,
                //AccountStatusId = DataSeedingValues.AccountStatuses.Registered.Id             
            };

            var result = await _userRepository.RemoveAsync(user.Id);

            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(
            [FromBody] LoginDto loginDto,
            CancellationToken cancellationToken)
        {
            var username = "khai2904";
            var userId = DefaultValues.SystemId;
            var avatarUrl = DefaultValues.UserAvatarUrl;

            var jwtToken = GenerateToken();
            return Ok($"token: {jwtToken}");

            string GenerateToken()
            {
                var accessTokenId = Guid.NewGuid();

                var token = new JwtSecurityToken(
                    issuer: _jwtOptions.Issuer,
                    audience: _jwtOptions.Audience,
                    claims: new List<Claim>(4)
                    {
                        new(type: JwtRegisteredClaimNames.Jti, accessTokenId.ToString()),
                        new(type: JwtRegisteredClaimNames.Sub, userId.ToString()),
                        new(type: "username", username),
                        new(type: "avatarUrl", avatarUrl)
                    },
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: new SigningCredentials(
                        key: _jwtOptions.GetSecurityKey(),
                        algorithm: SecurityAlgorithms.HmacSha256));

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
        }

        [HttpGet("test-auth")]
        public IActionResult TestAuth()
        {
            var userCredentials = HttpContext.User;

            var url = userCredentials.FindFirst(claim => claim.Type.Equals("avatarUrl"));

            return Ok();
        }
    }
}
