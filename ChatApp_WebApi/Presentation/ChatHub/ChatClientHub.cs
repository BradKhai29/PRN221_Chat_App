using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Presentation.ChatHub.Base;
using Presentation.ChatHub.ChatConnection;

namespace Presentation.ChatHub;

/// <summary>
/// Represents a hub for managing chat clients.
/// </summary>
public class ChatClientHub : Hub<IChatClient>
{
    private readonly IHubContext _hubContext;
    private readonly Chat _connections;
    public ChatClientHub(IHubContext hubContext)
    {
        _hubContext = hubContext;
    }
    public async Task ReceiveMessage(string user, string message)
    {
        await _hubContext.Clients.All.SendAsync("ReceiveMessage", user, message);

    }

    public async Task SendMessage(string user, string message)
    {
        await _hubContext.Clients.All.SendAsync("ReceiveMessage", user, message);
    }

    public async Task SendMessageToGroup(string user, string message, string groupName)
    {
        if (_connections.GetValueOfKey())
        {
            await _hubContext.Clients.Group(groupName).SendAsync("ReceiveMessage", user, message);
        }
    }
}