using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Core.Entities;
using Presentation.DTOs.Implementation.ChatMessages.InComings;


namespace Presentation.ChatHub.Base;

public interface IGroupClient
{

    Task SendAsync(string groupName, CreateChatMessageDto message);
    Task SendAsync(string groupName, string message);

}