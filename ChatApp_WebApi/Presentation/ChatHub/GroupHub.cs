
using System.Text.RegularExpressions;
using BusinessLogic.Services.Entities.Base;
using DataAccess.Core.Entities;
using Microsoft.AspNetCore.SignalR;
using Presentation.ChatHub.Base;
using Presentation.ChatHub.ChatConnection;
using Presentation.DTOs.Implementation.ChatMessages.InComings;


namespace Presentation.ChatHub;

/// <summary>
/// Represents a hub for managing group chat functionality.
/// </summary>
public sealed class GroupHub : Hub<IGroupClient>
{
    private readonly IUserHandlingService _userHandlingService;
    private readonly IChatGroupHandlingService _groupHandlingServices;
    public GroupHub(IUserHandlingService userHandlingService, IChatGroupHandlingService groupHandlingServices)
    {
        _userHandlingService = userHandlingService;
        _groupHandlingServices = groupHandlingServices;
    }

    public async Task SendToGroup(Guid groupId, string message)
    {
        try
        {
            var user = _userHandlingService.FindUserByNameAsync(Context.User.Identity.Name, default);
            var group = _groupHandlingServices.FindByIdAsync(groupId, default);
            var messageDto = new CreateChatMessageDto
            {
                Content = message,
                ChatGroupId = groupId,
                ReplyMessageId = Guid.Empty,
                CreatedAt = DateTime.UtcNow
            };
            if (!string.IsNullOrEmpty(message.Trim()))
            {
                var msg = new ChatMessageEntity
                {
                    Content = Regex.Replace(message, @"(?i)<(img|a|/a|/img).*?>", ""),
                    Images = null,
                    Sender = user.Result,
                    ReplyMessage = null,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };

                await Clients.Group(group.Result.Name.ToString()).SendAsync("newMessage", messageDto);
            }
        }
        catch (Exception e)
        {
            var errorMessage = "Message cannot be sent" + e.Message;
            var errorMsg = new CreateChatMessageDto
            {
                Content = errorMessage,
                ChatGroupId = Guid.Empty,
                CreatedAt = DateTime.UtcNow,
                ReplyMessageId = Guid.Empty,
                Images = null
            };
            await Clients.Caller.SendAsync("OnError", errorMsg);
        }
    }
    public async Task JoinGroup(Guid groupId)
    {
        try
        {
            var user = await _userHandlingService.FindUserByNameAsync(Context.User.Identity.Name, default);

            await Groups.AddToGroupAsync(Context.ConnectionId, groupId.ToString());

            await Clients.OthersInGroup(groupId.ToString()).SendAsync("User Joined", user.NormalizedUserName);

        }
        catch (Exception e)
        {
            await Clients.Caller.SendAsync("OnError", e.Message);
        }
    }
    public async Task Leave(Guid groupId)
    {
        var groupName = _groupHandlingServices.FindByIdAsync(groupId, default).Result.Name;

        await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName.ToString());
    }
}