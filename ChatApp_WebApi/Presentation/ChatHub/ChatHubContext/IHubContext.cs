using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Presentation.ChatHub.Base;

namespace Presentation.ChatHub.ChatHubContext;

/// <summary>
/// Represents the hub context for a specific hub.
/// </summary>
/// <typeparam name="THub">The type of the hub.</typeparam>
public interface IHubContext<THub> where THub : Hub
{
    IGroupManager Groups { get; }
    INotificationClient NotifClients { get; }
    IHubClients Clients { get; }

}