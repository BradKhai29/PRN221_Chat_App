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
using DataAccess.Core.Entities;

namespace Presentation.ChatHub;

/// <summary>
/// Represents a hub for managing chat clients.
/// </summary>
public class ChatClientHub : Hub<IChatClient>
{
    private readonly Connections<Chat> _connections = new();
    private readonly IUserHandlingService _userHandlingService;
    private readonly IChatGroupHandlingService _groupHandlingServices;
    private readonly IChatMessageHandlingService _chatMessageHandlingService;

    public ChatClientHub(IUserHandlingService userHandlingService, IChatGroupHandlingService groupHandlingService, IChatMessageHandlingService chatMessageHandlingService)
    {
        _userHandlingService = userHandlingService;
        _groupHandlingServices = groupHandlingService;
        _chatMessageHandlingService = chatMessageHandlingService;
    }


    public async Task SendMessagePrivate(string receiverName, string message)
    {
        if (_connections.All.TryGetValue(receiverName, out var userId))
        {

            var sender = await _userHandlingService.FindUserByNameAsync(receiverName, default);
            if (!string.IsNullOrEmpty(message.Trim()))
            {
                //build message
                var msg = new ChatMessageEntity
                {
                    Content = Regex.Replace(message, @"(?i)<(img|a|/a|/img).*?>", ""),
                    Sender = sender,
                    CreatedAt = DateTime.Now,
                    Images = null,
                    ReplyMessage = null,
                    UpdatedAt = DateTime.Now
                };
                await _chatMessageHandlingService.CreateAsync(msg, default);
                //send message
                await Clients.Client(userId.ToString()).SendAsync("newMessage", msg: msg);
                await Clients.Caller.SendAsync("newMessage", msg);
            }
        }
    }


}