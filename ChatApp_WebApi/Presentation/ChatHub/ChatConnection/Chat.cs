using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Presentation.ChatHub.ChatConnection;

/// <summary>
/// Represents a chat hub connection.
/// </summary>
public class Chat : Hub
{
    private readonly Connections<Chat> _connections;

    public Chat(Connections<Chat> connections)
    {
        _connections = connections;
    }
    public override Task OnConnectedAsync()
    {

        _connections.All.TryAdd(Context.ConnectionId, Context);

        return base.OnConnectedAsync();
    }
    public override Task OnDisconnectedAsync(Exception? exception)
    {
        _connections.All.TryRemove(Context.ConnectionId, out _);

        return base.OnDisconnectedAsync(exception);
    }
    public bool GetValueOfKey()
    {
        return _connections.All.TryGetValue(Context.ConnectionId, out _);
    }
}