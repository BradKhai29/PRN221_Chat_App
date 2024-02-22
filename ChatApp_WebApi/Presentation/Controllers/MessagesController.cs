
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Presentation.ChatHub;
using Presentation.ChatHub.Base;
using Presentation.ChatHub.ChatConnection;

namespace Presentation.Controllers;
[Authorize]
[ApiController]
[Route("api/[controller]")]
public class MessagesController : ControllerBase
{
    private readonly Chat _connections;
    private readonly IHubContext<ChatClientHub, IChatClient> _hubContext;
    public MessagesController(IHubContext<ChatClientHub, IChatClient> hubContext)
    {
        _hubContext = hubContext;
    }
    [HttpPost("send")]
    public async Task<IActionResult> SendMessageToGroup(string message, string name, string groupName)
    {
        if (name == null || message == null || groupName == null)
        {
            return BadRequest();
        }
        if (_connections.GetValueOfKey())
        {
            await _hubContext.Clients
                    .Group(groupName: groupName)
                    .ReceiveMessage(user: name, message: message);
        }
        return Ok();
    }
}