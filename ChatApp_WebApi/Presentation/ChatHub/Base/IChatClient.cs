using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Core.Entities;
using Presentation.Models.ViewModel;

namespace Presentation.ChatHub.Base;

/// <summary>
/// Represents a chat client interface.
/// </summary>
public interface IChatClient
{
    Task ReceiveMessage(string user, string message);
    Task SendAsync(string message, ChatMessageEntity msg);
}