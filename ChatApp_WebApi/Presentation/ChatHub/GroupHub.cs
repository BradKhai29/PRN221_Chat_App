
using System.Text.RegularExpressions;
using BusinessLogic.Services.Entities.Base;
using Microsoft.AspNetCore.SignalR;
using Presentation.ChatHub.Base;
using Presentation.Models.ViewModel;

namespace Presentation.ChatHub;

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
            var user = await _userHandlingService.FindUserByNameAsync(Context.User.Identity.Name, default);
            await Groups.AddToGroupAsync(Context.ConnectionId, groupId.ToString());
            await Clients.OthersInGroup(groupId.ToString()).SendAsync("UserJoined", user.NormalizedUserName);

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