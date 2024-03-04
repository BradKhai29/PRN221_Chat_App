using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Presentation.Models.ViewModel;

namespace Presentation.ChatHub.Base;

public interface IGroupClient
{
    Task JoinGroupAsync(string groupName);
    Task LeaveGroupAsync(string groupName);
    Task SendAsync(string groupName, MessageViewModel message);
    Task SendAsync(string groupName, string message);

}