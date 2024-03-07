
using BusinessLogic.Services.Entities.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Presentation.ChatHub;
using Presentation.ChatHub.Base;
using Presentation.ChatHub.ChatConnection;
using Presentation.Commons.Constants;

namespace Presentation.Controllers;
[Authorize(Policy = AuthorizationPolicyNames.UserRequirement)]
[ApiController]
[Route("api/[controller]")]
public class ChatController : ControllerBase
{
    private readonly Chat _connections;

    private readonly IHubContext<ChatClientHub, IChatClient> _hubContext;
    private readonly IChatGroupHandlingService _groupService;
    public ChatController(IHubContext<ChatClientHub, IChatClient> hubContext, IChatGroupHandlingService groupService)
    {
        _groupService = groupService;
        _hubContext = hubContext;
    }
    [HttpPost("send")]
    public async Task<IActionResult> SendMessageToGroup(string message,
    string name,
    Guid groupId)
    {
        var group = await _groupService.FindByIdAsync(groupId, default);
        if (name == null || message == null || group == null)
        {
            return BadRequest();
        }
        if (_connections.GetValueOfKey())
        {
            await _hubContext.Clients
                    .Group(groupName: group.Name)
                    .ReceiveMessage(user: name, message: message);
        }
        return Ok();
    }

}