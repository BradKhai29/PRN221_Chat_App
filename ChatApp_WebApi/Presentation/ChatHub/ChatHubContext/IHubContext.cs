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
public interface IHubContext<THub, T> where THub : Hub<T> where T : class
{
    /// <summary>
    /// Gets the manager for groups in the hub context.
    /// </summary>
    IGroupManager Groups { get; }
    /// <summary>
    /// Gets the notification client for sending notifications.
    /// </summary>
    INotificationClient NotifClients { get; }
    /// <summary>
    /// Gets the clients connected to the hub.
    /// </summary>
    IHubClients Clients { get; }

}