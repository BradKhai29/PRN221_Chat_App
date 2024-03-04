using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.ChatHub.Base;

public interface IGroupClient
{
    Task JoinGroupAsync(string groupName);
    Task LeaveGroupAsync(string groupName);

}