using Presentation.ChatHub.Base;
using Microsoft.AspNetCore.SignalR;

namespace Presentation.ChatHub;

/// <summary>
/// Represents a hub for sending notifications.
/// </summary>
public class NotificationHub : Hub<INotificationClient>
{

}