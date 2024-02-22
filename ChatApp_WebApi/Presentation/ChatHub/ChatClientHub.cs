using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Presentation.ChatHub.Base;

namespace Presentation.ChatHub
{
    /// <summary>
    /// Represents a hub for managing chat clients.
    /// </summary>
    public class ChatClientHub : Hub<IChatClient>
    {
        /// <summary>
        /// Sends a message to the specified group.
        /// </summary>
        /// <param name="user">The user sending the message.</param>
        /// <param name="message">The message to be sent.</param>
        /// <param name="groupName">The name of the group to send the message to.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task SendMessage(string user, string message, string groupName)
        {
            await Clients.Group(groupName).ReceiveMessage(user, message);
        }
    }
}