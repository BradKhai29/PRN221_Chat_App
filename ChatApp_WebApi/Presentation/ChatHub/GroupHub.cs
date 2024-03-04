
using Microsoft.AspNetCore.SignalR;
using Presentation.ChatHub.Base;

namespace Presentation.ChatHub;

public sealed class GroupHub : Hub, IGroupClient
{
    private readonly IHubContext _hubContext;
    public GroupHub(IHubContext hubContext)
    {
        _hubContext = hubContext;
    }
    public async Task JoinGroupAsync(string groupName)
    {
        await _hubContext.Groups.AddToGroupAsync(Context.ConnectionId, groupName);
    }
    public async Task LeaveGroupAsync(string groupName)
    {
        await _hubContext.Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
    }
}