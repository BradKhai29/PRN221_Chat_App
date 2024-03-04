using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.ChatHub.Base;

/// <summary>
/// Represents a client for receiving notifications.
/// </summary>
public interface INotificationClient
{
    Task ReceiveNotification(string content);
    Task JoinGroupNotification(string roomName);

}