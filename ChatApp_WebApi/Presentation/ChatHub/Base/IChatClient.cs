using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.ChatHub.Base;

/// <summary>
/// Represents a chat client interface.
/// </summary>
public interface IChatClient
{
    Task SendMessageToGroup(string user, string message, string groupName);
    Task ReceiveMessage(string user, string message);
    Task SendMessage(string user, string message);
}