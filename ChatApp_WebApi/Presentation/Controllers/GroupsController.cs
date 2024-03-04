using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Presentation.ChatHub;
using Presentation.ChatHub.Base;

namespace Presentation.Controllers;
[Authorize]
[ApiController]
[Route("api/[controller]")]
public class GroupsController : ControllerBase
{
    private readonly IGroupClient _groupClient;
    public GroupsController(IGroupClient groupClient)
    {
        _groupClient = groupClient;
    }
    // public async Task<IActionResult> JoinGroup([FromBody]string groupName)
    // {

    // }
}