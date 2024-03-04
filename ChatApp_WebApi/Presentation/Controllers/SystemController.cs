using DataAccess.Commons.DataSeedings;
using DataAccess.Commons.SystemConstants;
using DataAccess.Core;
using DataAccess.Core.Entities;
using DataAccess.UnitOfWorks.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Commons.Constants;
using System.Net.Mime;

namespace Presentation.Controllers
{
    [ApiController]
    //[Authorize(Policy = AuthorizationPolicyNames.AdminRequirement)]
    [Route("api/[controller]")]
    [Consumes(contentType: MediaTypeNames.Application.Json)]
    [Produces(contentType: MediaTypeNames.Application.Json)]
    public class SystemController : ControllerBase
    {
        private readonly IUnitOfWork<ChatAppDbContext> _unitOfWork;

        public SystemController(IUnitOfWork<ChatAppDbContext> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddAsync()
        {
            var user = new UserEntity
            {
                Id = DefaultValues.SystemId,
                UserName = "system",
                PasswordHash = "system",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                RemovedAt = DefaultValues.MinDateTime,
                AvatarUrl = DefaultValues.UserAvatarUrl,
                Email = "system@mail.com",
                PhoneNumber = string.Empty,
                AccountStatusId = SeedingValues.AccountStatuses.EmailConfirmed.Id
            };

            var result = await _unitOfWork.UserRepository.AddAsync(user);

            return Ok();
        }

        [HttpGet("add/role")]
        public async Task<IActionResult> AddRoleAsync()
        {
            var systemId = DefaultValues.SystemId;

            var seedEntities = new List<RoleEntity>(capacity: 5)
            {
                new()
                {
                    Id = SeedingValues.Roles.DoNotRemove.Id,
                    Name = SeedingValues.Roles.DoNotRemove.Name,
                    NormalizedName = SeedingValues.Roles.DoNotRemove.Name.ToUpper(),
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = systemId
                },
                //new()
                //{
                //    Id = SeedingValues.Roles.System.Id,
                //    Name = SeedingValues.Roles.System.Name,
                //    NormalizedName = SeedingValues.Roles.System.Name.ToUpper(),
                //    CreatedAt = DateTime.UtcNow,
                //    CreatedBy = systemId
                //},
                //new()
                //{
                //    Id = SeedingValues.Roles.User.Id,
                //    Name = SeedingValues.Roles.User.Name,
                //    NormalizedName = SeedingValues.Roles.User.Name.ToUpper(),
                //    CreatedAt = DateTime.UtcNow,
                //    CreatedBy = systemId
                //},
                //new()
                //{
                //    Id = SeedingValues.Roles.ChatGroupMember.Id,
                //    Name = SeedingValues.Roles.ChatGroupMember.Name,
                //    NormalizedName = SeedingValues.Roles.ChatGroupMember.Name.ToUpper(),
                //    CreatedAt = DateTime.UtcNow,
                //    CreatedBy = systemId
                //},
                //new()
                //{
                //    Id = SeedingValues.Roles.ChatGroupManager.Id,
                //    Name = SeedingValues.Roles.ChatGroupManager.Name,
                //    NormalizedName = SeedingValues.Roles.ChatGroupManager.Name.ToUpper(),
                //    CreatedAt = DateTime.UtcNow,
                //    CreatedBy = systemId
                //}
            };

            foreach (var entity in seedEntities)
            {
                await _unitOfWork.RoleRepository.AddAsync(entity);
            }

            return Ok();
        }
    }
}
