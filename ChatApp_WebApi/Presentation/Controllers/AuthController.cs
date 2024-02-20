using DataAccess.Commons.DataSeedings;
using DataAccess.Commons.SystemConstants;
using DataAccess.Core.Entities;
using DataAccess.Repositories.Base;
using DataAccess.Specifications.Managers.SuperManager.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Presentation.Models.Options;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JwtOptions _jwtOptions;
        private readonly IUserRepository _userRepository;

        public AuthController(IOptions<JwtOptions> jwtOptions, IUserRepository userRepository)
        {
            _jwtOptions = jwtOptions.Value;
            _userRepository = userRepository;
        }

        [HttpGet(nameof(Test))]
        public IActionResult Test()
        {
            return Ok(new
            {
                HashCode = _jwtOptions.GetHashCode(),
                Value = _jwtOptions
            });
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
    }
}
