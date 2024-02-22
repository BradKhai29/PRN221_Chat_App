using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Presentation.ChatHub.ChatHubContext;
using Presentation.ChatHub.Base;
using Microsoft.AspNetCore.SignalR;

namespace Presentation.ChatHub;

/// <summary>
/// Represents a hub for sending notifications.
/// </summary>
public sealed class NotificationHub : Hub<INotificationClient>
{
    /// <summary>
    /// Sends a notification with the specified content to all clients.
    /// </summary>
    /// <param name="content">The content of the notification.</param>
    public async Task SendNotification(string content)
    {
        await Clients.All.ReceiveNotification(content);
    }
    public async Task JoinRoomNotification(string userName, string roomName){
        
    }
}