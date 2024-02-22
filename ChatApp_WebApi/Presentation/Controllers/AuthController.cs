using BusinessLogic.Commons.Constants;
using BusinessLogic.Models;
using BusinessLogic.Services.Entities.Base;
using BusinessLogic.Services.Externals.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.DTOs.Implementation.Auths.InComings;
using Presentation.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IRefreshTokenHandlingService _refreshTokenService;
        private readonly IAccessTokenHandlingService _accessTokenService;
        private readonly IAuthHandlingService _authService;
        private readonly IUserHandlingService _userService;

        public AuthController(
            IAccessTokenHandlingService accessTokenHandlingService,
            IRefreshTokenHandlingService refreshTokenHandlingService,
            IAuthHandlingService authService,
            IUserHandlingService userService)
        {
            _accessTokenService = accessTokenHandlingService;
            _refreshTokenService = refreshTokenHandlingService;
            _authService = authService;
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(
            [FromBody] RegisterDto registerDto,
            CancellationToken cancellationToken)
        {
            registerDto.NormalizeAllProperties();

            var isExisted = await _userService.IsEmailExistedAsync(
                email: registerDto.Email,
                cancellationToken: cancellationToken);

            if (isExisted)
            {
                return BadRequest(CommonResponse.Failed(new List<string>
                {
                    "Email is already existed."
                }));
            }

            isExisted = await _userService.IsUsernameExistedAsync(
                username: registerDto.Username,
                cancellationToken: cancellationToken);

            if (isExisted)
            {
                return BadRequest(CommonResponse.Failed(new List<string>
                {
                    "Username is already existed."
                }));
            }

            var result = await _authService.RegisterAsync(
                registerInfo: new RegisterInfo
                {
                    Username = registerDto.Username,
                    Email = registerDto.Email,
                    Password = registerDto.Password
                },
                cancellationToken: cancellationToken);

            if (result)
            {
                return Ok(CommonResponse.Success);
            }

            return StatusCode(StatusCodes.Status500InternalServerError, CommonResponse.Failed(new List<string>
                {
                    "Something wrong with database."
                }));
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(
            [FromBody] LoginDto loginDto,
            CancellationToken cancellationToken)
        {
            loginDto.NormalizeAllProperties();

            var result = await _authService.LoginAsync(
                username: loginDto.Username,
                password: loginDto.Password,
                cancellationToken: cancellationToken);

            if (!result.IsSuccess)
            {
                return BadRequest("Login credentials is invalid");
            }

            var user = result.Value;
            var lifeSpan = TimeSpan.FromDays(7);

            var refreshToken = _refreshTokenService.Generate(user.Id, lifeSpan);

            var claims = new List<Claim>(4)
            {
                new(type: JwtRegisteredClaimNames.Jti, refreshToken.AccessTokenId.ToString()),
                new(type: JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new(type: UserCustomClaimTypes.Username, user.UserName),
                new(type: UserCustomClaimTypes.AvatarUrl, user.AvatarUrl)
            };

            var accessToken = _accessTokenService.GenerateJwtToken(
                claims: claims,
                liveSpan: lifeSpan);

            return Ok(CommonResponse.Success(value: accessToken));
        }

        [Authorize]
        [HttpGet("test-auth")]
        public IActionResult TestAuth()
        {
            var userCredentials = HttpContext.User;

            var url = userCredentials.FindFirst(claim => claim.Type.Equals("avatarUrl"));

            return Ok();
        }
    }
}
