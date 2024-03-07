
using BusinessLogic.Services.Entities.Base;
using Presentation.ChatHub.Base;
using Presentation.ChatHub.ChatConnection;
using Microsoft.AspNetCore.SignalR;
using System.Text.RegularExpressions;
using DataAccess.Core.Entities;
using Presentation.DTOs.Implementation.ChatMessages.InComings;

namespace Presentation.ChatHub;

/// <summary>
/// Represents a hub for managing chat clients.
/// </summary>
public class ChatClientHub : Hub<IChatClient>
{
    private readonly Connections<Chat> _connections = new();
    private readonly IUserHandlingService _userHandlingService;
    private readonly IChatMessageHandlingService _chatMessageHandlingService;

    public ChatClientHub(IUserHandlingService userHandlingService, IChatMessageHandlingService chatMessageHandlingService)
    {
        _userHandlingService = userHandlingService;
        _chatMessageHandlingService = chatMessageHandlingService;
    }

    /// <summary>
    /// Sends a private message to a specific receiver.
    /// </summary>
    /// <param name="receiverName">The name of the receiver.</param>
    /// <param name="message">The message data.</param>
    public async Task SendMessagePrivate(string receiverName, string message)
    {
        if (_connections.All.TryGetValue(receiverName, out var userId))
        {
            var sender = await _userHandlingService.FindUserByNameAsync(Context.User.Identity.Name, default);
            var messageDto = new CreateChatMessageDto
            {
                Content = message,
                ChatGroupId = Guid.Empty,
                ReplyMessageId = Guid.Empty,
                CreatedAt = DateTime.UtcNow
            };
            if (!string.IsNullOrEmpty(messageDto.Content))
            {
                //build message
                var msg = new ChatMessageEntity
                {
                    Content = Regex.Replace(messageDto.Content, @"(?i)<(img|a|/a|/img).*?>", ""),
                    Images = null,
                    Sender = sender,
                    ReplyMessage = null,
                    CreatedAt = messageDto.CreatedAt,
                    CreatedBy = sender.Id
                };
                await _chatMessageHandlingService.CreateAsync(msg, default);
                //send message
                await Clients.Client(userId.ToString()).SendAsync("New message:", msg: messageDto);

                await Clients.Caller.SendAsync("New message:", messageDto);
            }
        }
    }


}