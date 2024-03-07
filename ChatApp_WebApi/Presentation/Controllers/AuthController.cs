using BusinessLogic.Models;
using BusinessLogic.Services.Entities.Base;
using BusinessLogic.Services.Externals.Base;
using DataAccess.Commons.DataSeedings;
using DataAccess.Core.Entities;
using Helpers.Commons.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.DTOs.Implementation.Auths.InComings;
using Presentation.DTOs.Implementation.Auths.OutGoings;
using Presentation.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Mime;
using System.Security.Claims;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    public class AuthController : ControllerBase
    {
        #region Private constants
        // Confirm email.
        private const string ConfirmEmailEndpointTemplate = "confirm-email";
        private const string ConfirmEmailEndpoint = "api/auth/confirm-email";
        // Reset password.
        private const string ResetPasswordEndpointTemplate = "reset-password";
        private const string ResetPasswordEndpoint = "api/auth/reset-password";

        private const string TemplateFolder = "Templates";
        private const string MailTemplateFileName = "mail.html";
        #endregion

        // Backing fields
        private readonly IRefreshTokenHandlingService _refreshTokenService;
        private readonly IUserTokenHandlingService _tokenService;
        private readonly IAuthHandlingService _authService;
        private readonly IUserHandlingService _userService;
        private readonly IMailHandlingService _mailService;
        private readonly IHostEnvironment _hostEnvironment;

        public AuthController(
            IRefreshTokenHandlingService refreshTokenHandlingService,
            IUserTokenHandlingService tokenHandlingService,
            IAuthHandlingService authHandlingService,
            IUserHandlingService userHandlingService,
            IMailHandlingService mailHandlingService,
            IHostEnvironment hostEnvironment)
        {
            _tokenService = tokenHandlingService;
            _refreshTokenService = refreshTokenHandlingService;
            _authService = authHandlingService;
            _userService = userHandlingService;
            _mailService = mailHandlingService;
            _hostEnvironment = hostEnvironment;
        }

        /// <summary>
        ///     Register a new user account with provided credentials.
        /// </summary>
        /// <param name="registerDto">
        ///     This object contains required credentials that 
        ///     need to create a new user account.
        /// </param>
        /// <param name="cancellationToken"></param>
        /// <returns>
        ///     A message of registration process.
        /// </returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST api/Auth/register
        ///     {
        ///         "username": "abc123",
        ///         "email": "user@example.com",
        ///         "password": "string"
        ///     }
        ///
        /// </remarks>
        /// <response code="400">Invalid register credentials.</response>
        /// <response code="404">Email is not real.</response>
        /// <response code="200">Registerd success.</response>
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(
            [FromBody] RegisterDto registerDto,
            CancellationToken cancellationToken)
        {
            registerDto.NormalizeAllProperties();

            // Verify the register credentials.
            var isExisted = await _authService.IsEmailExistedAsync(
                email: registerDto.Email,
                cancellationToken: cancellationToken);

            if (isExisted)
            {
                return BadRequest(CommonResponse.Failed(new List<string>(1)
                {
                    "Email has been registered."
                }));
            }

            isExisted = await _authService.IsUsernameExistedAsync(
                username: registerDto.Username,
                cancellationToken: cancellationToken);

            if (isExisted)
            {
                return BadRequest(CommonResponse.Failed(new List<string>(1)
                {
                    "Username has been registered."
                }));
            }

            // Create a new user account.
            var result = await _authService.RegisterAsync(
                registerInfo: new RegisterInfoModel
                {
                    Username = registerDto.Username,
                    Email = registerDto.Email,
                    Password = registerDto.Password
                },
                cancellationToken: cancellationToken);

            if (!result.IsSuccess)
            {
                return StatusCode(
                    statusCode: StatusCodes.Status500InternalServerError,
                    value: CommonResponse.Failed(new List<string>(1)
                    {
                        "Database error occurred."
                    }));
            }

            return Ok(CommonResponse.Success());
        }

        /// <summary>
        ///     
        /// </summary>
        /// <param name="loginDto"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(
            [FromBody] LoginDto loginDto,
            CancellationToken cancellationToken)
        {
            loginDto.NormalizeAllProperties();

            // Verify the login credentials.
            var result = await _authService.LoginAsync(
                username: loginDto.Username,
                password: loginDto.Password,
                cancellationToken: cancellationToken);

            if (!result.IsSuccess)
            {
                return BadRequest(error: CommonResponse.Failed(new List<string>(1)
                {
                    "Login credentials is invalid"
                }));
            }

            // Generate refresh-token and access-token.
            var user = result.Value;

            var refreshToken = _refreshTokenService.Generate(
                userId: user.Id,
                rememberMe: loginDto.RememberMe);

            var dbResult = await _refreshTokenService.AddAsync(
                refreshToken: refreshToken,
                cancellationToken: cancellationToken);

            if (!dbResult)
            {
                return StatusCode(
                    statusCode: StatusCodes.Status500InternalServerError,
                    value: CommonResponse.Failed(new List<string>(1)
                    {
                        CommonResponse.DatabaseErrorMessage
                    }));
            }

            // Generate access-token section.
            var claims = new List<Claim>(4)
            {
                new(type: JwtRegisteredClaimNames.Jti, refreshToken.AccessTokenId.ToString()),
                new(type: JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new(type: UserCustomClaimTypes.Username, user.UserName),
                new(type: UserCustomClaimTypes.AvatarUrl, user.AvatarUrl)
            };

            var accessTokenLifeSpan = loginDto.RememberMe
                ? TimeSpan.FromDays(1)
                : TimeSpan.FromDays(7);

            var accessToken = _tokenService.GenerateAccessToken(
                claims: claims,
                lifeSpan: accessTokenLifeSpan);

            return Ok(CommonResponse.Success(body: new LoginSuccessDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken.Value
            }));
        }

        /// <summary>
        ///     Do the email confirmation for user with the provided
        ///     email-confirmation-token.
        /// </summary>
        /// <param name="emailConfirmToken">
        ///     The token that used for email confirmation.
        /// </param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet(template: ConfirmEmailEndpointTemplate)]
        public async Task<IActionResult> ConfirmEmailAsync(
            [FromQuery(Name = "token")] string emailConfirmToken,
            CancellationToken cancellationToken)
        {
            var result = await _tokenService.VerifyEmailConfirmationTokenAsync(
                confirmationToken: emailConfirmToken,
                cancellationToken: cancellationToken);

            if (!result.IsSuccess)
            {
                return BadRequest(CommonResponse.Failed(new List<string>(capacity: 1)
                {
                    CommonResponse.InvalidTokenMessage
                }));
            }

            // Verify if user has confirmed their email or not.
            var user = result.Value;

            var isEmailConfirmed = await _userService.IsEmailConfirmedByUserIdAsync(
                userId: user.Id,
                cancellationToken: cancellationToken);

            if (isEmailConfirmed)
            {
                return StatusCode(
                    statusCode: StatusCodes.Status409Conflict,
                    value: CommonResponse.Failed(new List<string>
                    {
                        "Email has been confirmed."
                    }));
            }

            // Confirm email for the specified user.
            user.AccountStatusId = SeedingValues.AccountStatuses.EmailConfirmed.Id;

            var confirmSuccess = await _authService.ConfirmEmailForUserAsync(
                user: user,
                cancellationToken: cancellationToken);

            if (!confirmSuccess)
            {
                return StatusCode(
                    statusCode: StatusCodes.Status500InternalServerError,
                    value: CommonResponse.Failed(new List<string>
                    (1) {
                        CommonResponse.DatabaseErrorMessage
                    }));
            }

            return Ok(CommonResponse.Success());
        }

        [HttpPost("confirm-email/resend")]
        public async Task<IActionResult> ResendEmailForConfirmationAsync(
            [FromBody]
            InputEmailDto dto,
            CancellationToken cancellationToken)
        {
            var foundUser = await _userService.FindUserByEmailAsync(
                email: dto.Email,
                cancellationToken: cancellationToken);

            if (Equals(objA: foundUser, objB: null))
            {
                return NotFound(CommonResponse.Failed(new List<string>
                {
                    "The provided email is not existed."
                }));
            }

            var isEmailConfirmed = await _userService.IsEmailConfirmedByUserIdAsync(
                userId: foundUser.Id,
                cancellationToken: cancellationToken);

            if (isEmailConfirmed)
            {
                return StatusCode(
                    statusCode: StatusCodes.Status409Conflict,
                    value: CommonResponse.Failed(new List<string>
                    {
                        "Email has been confirmed."
                    }));
            }

            var isSuccess = await SendMailForConfirmationAsync(
                email: dto.Email,
                userId: foundUser.Id,
                cancellationToken: cancellationToken);

            if (!isSuccess)
            {
                return StatusCode(
                    statusCode: StatusCodes.Status500InternalServerError,
                    value: CommonResponse.Failed(messages: new List<string>(capacity: 1)
                    {
                        "Something when trying to send the register confirmation email."
                    }));
            }

            return Ok(CommonResponse.Success());
        }

        /// <summary>
        ///     Sending a reset-password email to the input email.
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPasswordByEmailAsync(
            [FromBody]
            InputEmailDto dto,
            CancellationToken cancellationToken)
        {
            var foundUser = await _userService.FindUserByEmailAsync(
                email: dto.Email,
                cancellationToken: cancellationToken);

            if (Equals(objA: foundUser, objB: null))
            {
                return NotFound(CommonResponse.Failed(new List<string>
                {
                    "The provided email is not existed."
                }));
            }

            var resetPasswordToken = await _tokenService.FindResetPasswordTokenByUserIdAsync(
                foundUser.Id,
                cancellationToken: cancellationToken);

            // Create the reset-password token.
            if (Equals(objA: resetPasswordToken, objB: null))
            {
                resetPasswordToken = _tokenService.CreateResetPasswordToken(userId: foundUser.Id);

                var result = await _tokenService.SaveTokenAsync(resetPasswordToken, cancellationToken);

                if (!result)
                {
                    return StatusCode(
                    statusCode: StatusCodes.Status500InternalServerError,
                    value: CommonResponse.Failed(messages: new List<string>(capacity: 1)
                    {
                        CommonResponse.DatabaseErrorMessage
                    }));
                }
            }

            var isSuccess = await SendMailForResetPasswordAsync(
                email: dto.Email,
                resetPasswordToken: resetPasswordToken,
                cancellationToken: cancellationToken);

            if (!isSuccess)
            {
                return StatusCode(
                    statusCode: StatusCodes.Status500InternalServerError,
                    value: CommonResponse.Failed(messages: new List<string>(capacity: 1)
                    {
                        "Something wrong when trying to send reset-password email."
                    }));
            }

            return Ok(CommonResponse.Success());
        }

        /// <summary>
        ///     Do the email confirmation for user with the provided
        ///     email-confirmation-token.
        /// </summary>
        /// <param name="emailConfirmToken">
        ///     The token that used for email confirmation.
        /// </param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet(template: ResetPasswordEndpointTemplate)]
        public async Task<IActionResult> VerifyResetPasswordTokenAsync(
            [FromQuery(Name = "token")] string resetPasswordToken,
            CancellationToken cancellationToken)
        {
            var result = await _tokenService.VerifyResetPasswordTokenAsync(
                resetPasswordToken: resetPasswordToken,
                cancellationToken: cancellationToken);

            if (!result.IsSuccess)
            {
                return BadRequest(CommonResponse.Failed(new List<string>(1)
                {
                    CommonResponse.InvalidTokenMessage
                }));
            }

            return Ok(CommonResponse.Success());
        }

        [HttpPost(ResetPasswordEndpointTemplate)]
        public async Task<IActionResult> ResetPasswordAsync(
            ResetPasswordDto resetPasswordDto,
            CancellationToken cancellationToken)
        {
            resetPasswordDto.NormalizeAllProperties();

            var result = await _tokenService.VerifyResetPasswordTokenAsync(
                resetPasswordToken: resetPasswordDto.Token,
                cancellationToken: cancellationToken);

            if (!result.IsSuccess)
            {
                return BadRequest(CommonResponse.Failed(new List<string>(1)
                {
                    CommonResponse.InvalidTokenMessage
                }));
            }

            // Update user password.
            var user = result.Value;

            var isSuccess = await _userService.UpdatePasswordAsync(
                userId: user.Id,
                password: resetPasswordDto.Password,
                cancellationToken: cancellationToken);

            if (!isSuccess)
            {
                return StatusCode(
                   statusCode: StatusCodes.Status500InternalServerError,
                   value: CommonResponse.Failed(messages: new List<string>(capacity: 1)
                   {
                        CommonResponse.DatabaseErrorMessage
                   }));
            }

            await _tokenService.RemoveResetPasswordTokenAsync(
                userId: user.Id,
                cancellationToken: cancellationToken);

            return Ok(CommonResponse.Success());
        }

        [Authorize]
        [HttpGet("test-auth")]
        public IActionResult TestAuth()
        {
            var userCredentials = HttpContext.User;

            var url = userCredentials.FindFirst(claim => claim.Type.Equals("avatarUrl"));

            return Ok();
        }

        #region Private methods
        private async Task<bool> SendMailForConfirmationAsync(
            string email,
            Guid userId,
            CancellationToken cancellationToken)
        {
            // Send register confirmation email section.
            var mailTemplatePath = Path.Combine(
                path1: _hostEnvironment.ContentRootPath,
                path2: TemplateFolder,
                path3: MailTemplateFileName);

            var claims = new List<Claim>(1)
            {
                new(type: JwtRegisteredClaimNames.Sub, userId.ToString()),
            };

            // Generate confirmation token.
            var confirmationToken1 = _tokenService.GenerateEmailConfirmationToken(claims);
            var confirmationToken2 = _tokenService.GenerateEmailConfirmationToken(claims);

            // Generate confirmation uri for each token.
            var confirmationUri1 = $"{ConfirmEmailEndpoint}?token={confirmationToken1}";
            var confirmationUri2 = $"{ConfirmEmailEndpoint}?token={confirmationToken2}";

            var mailContent = await _mailService.GetMailContentAsync(
                templatePath: mailTemplatePath,
                to: email,
                subject: "ChatApp: Confirm your email.",
                linkedUri1: confirmationUri1,
                linkedUri2: confirmationUri2,
                cancellationToken: cancellationToken);

            return await _mailService.SendMailAsync(mailContent);
        }

        private async Task<bool> SendMailForResetPasswordAsync(
            string email,
            UserTokenEntity resetPasswordToken,
            CancellationToken cancellationToken)
        {
            // Send register confirmation email section.
            var mailTemplatePath = Path.Combine(
                path1: _hostEnvironment.ContentRootPath,
                path2: TemplateFolder,
                path3: MailTemplateFileName);

            var claims = new List<Claim>(2)
            {
                new(type: JwtRegisteredClaimNames.Sub, resetPasswordToken.UserId.ToString()),
                new(type: JwtRegisteredClaimNames.Jti, resetPasswordToken.Value),
            };

            // Generate confirmation token.
            var confirmationToken1 = _tokenService.GenerateResetPasswordToken(claims);
            var confirmationToken2 = _tokenService.GenerateResetPasswordToken(claims);

            // Generate confirmation uri for each token.
            var confirmationUri1 = $"{ResetPasswordEndpoint}?token={confirmationToken1}";
            var confirmationUri2 = $"{ResetPasswordEndpoint}?token={confirmationToken2}";

            var mailContent = await _mailService.GetMailContentAsync(
                templatePath: mailTemplatePath,
                to: email,
                subject: "ChatApp: Confirm your email.",
                linkedUri1: confirmationUri1,
                linkedUri2: confirmationUri2,
                cancellationToken: cancellationToken);

            return await _mailService.SendMailAsync(mailContent);
        }
        #endregion
    }
}
