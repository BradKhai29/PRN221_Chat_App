using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.ChatHub.Base
{
    public interface IChatClient
    {
        Task SendMessage(string message);
        Task ReceiveMessage(string user, string message);
    }
}