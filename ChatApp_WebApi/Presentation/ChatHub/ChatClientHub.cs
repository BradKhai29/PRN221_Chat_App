using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.Services.Entities.Base;
using Presentation.ChatHub.Base;
using Presentation.ChatHub.ChatConnection;
using Presentation.Models.ViewModel;
using Microsoft.AspNetCore.SignalR;
using System.Text.RegularExpressions;

namespace Presentation.ChatHub;

/// <summary>
/// Represents a hub for managing chat clients.
/// </summary>
public class ChatClientHub : Hub<IChatClient>
{
    private readonly Connections<Chat> _connections = new();
    private readonly IUserHandlingService _userHandlingService;
    private readonly IChatGroupHandlingService _groupHandlingServices;

    public ChatClientHub(IUserHandlingService userHandlingService, IChatGroupHandlingService groupHandlingService)
    {
        _userHandlingService = userHandlingService;
        _groupHandlingServices = groupHandlingService;
    }


    public async Task SendMessagePrivate(string receiverName, string message)
    {
        if (_connections.All.TryGetValue(receiverName, out var userId))
        {
            var sender = await _userHandlingService.FindUserByNameAsync(receiverName, default);
            if (!string.IsNullOrEmpty(message.Trim()))
            {
                //build message
                var messageViewModel = new MessageViewModel
                {
                    Content = Regex.Replace(message, @"\t|\n|\r", ""),
                    From = sender.NormalizedUserName,
                    To = receiverName,
                    SentTime = DateTime.Now
                };
                //send message
                await Clients.Client(userId.ToString()).SendAsync("newMessage", messageViewModel);
                await Clients.Caller.SendAsync("newMessage", messageViewModel);

            }
        }
    }

    public async Task SendToGroup(Guid groupId, string message)
    {
        try
        {
            var user = _userHandlingService.FindUserByNameAsync(Context.User.Identity.Name, default);
            var group = _groupHandlingServices.FindByIdAsync(groupId, default);
            if (!string.IsNullOrEmpty(message.Trim()))
            {
                var msg = new MessageGroupViewModel
                {
                    Content = Regex.Replace(message, @"\t|\n|\r", ""),
                    FromUser = user.Result.NormalizedUserName,
                    ToGroup = group.Result.Name,
                    SentTime = DateTime.Now
                };
                var messageToViewModel = new MessageViewModel
                {
                    Content = msg.Content,
                    From = msg.FromUser,
                    To = msg.ToGroup,
                    SentTime = msg.SentTime
                };
                await Clients.Group(group.Result.Name.ToString()).SendAsync("newMessage", messageToViewModel);
            }
        }
        catch (Exception e)
        {
            var errorMessage = "Message cannot be sent" + e.Message;
            var errorViewModel = new MessageViewModel
            {
                Content = errorMessage,
                From = "System",
                To = "Error",
                SentTime = DateTime.Now
            };
            await Clients.Caller.SendAsync("OnError", errorViewModel);
        }
    }
    public async Task JoinGroup(Guid groupId)
    {
        try
        {
            var user = _userHandlingService.FindUserByNameAsync(Context.User.Identity.Name, default);
            await Groups.AddToGroupAsync(Context.ConnectionId, groupId.ToString());
            await Clients.OthersInGroup(groupId.ToString()).SendAsync("UserJoined", user);
        }
    }
}