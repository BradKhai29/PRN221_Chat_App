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
    Task SendMessage(string message);
    Task ReceiveMessage(string user, string message);
}