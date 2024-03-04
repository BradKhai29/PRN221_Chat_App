using BusinessLogic.Services.Entities.Base;
using DataAccess.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Commons.Constants;
using Presentation.ExtensionMethods.Others;
using Presentation.Models;

namespace Presentation.Controllers
{
    [ApiController]
    [Authorize(Policy = AuthorizationPolicyNames.UserRequirement)]
    [Route("api/[controller]")]
    public class ChatGroupController : ControllerBase
    {
        // Backing fields.
        private readonly IChatGroupHandlingService _chatGroupService;
        private readonly IChatGroupMemberHandlingService _chatGroupMemberService;

        public ChatGroupController(
            IChatGroupHandlingService chatGroupHandlingService,
            IChatGroupMemberHandlingService chatGroupMemberHandlingService)
        {
            _chatGroupMemberService = chatGroupMemberHandlingService;
            _chatGroupService = chatGroupHandlingService;
        }


        [HttpGet("all")]
        public async Task<IActionResult> GetAllJoinedChatGroups(CancellationToken cancellationToken)
        {
            var user = HttpContext.User.GetUserEntity();

            var joinedChatGroups = await _chatGroupMemberService.GetAllJoinedGroupsByUserIdAsync(
                userId: user.Id,
                cancellationToken: cancellationToken);

            var isEmpty = Equals(joinedChatGroups, null);

            if (!isEmpty)
            {
                return Ok(CommonResponse.Success(body: joinedChatGroups));
            }

            var result = await _chatGroupService.CreateOnlyMeChatGroupByUserIdAsync(
                user: user,
                cancellationToken: cancellationToken);

            if (result.IsSuccess)
            {
                return Ok(CommonResponse.Success(result.Value));
            }

            return NotFound();
        }
    }
}
