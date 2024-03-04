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

}