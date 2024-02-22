using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Presentation.ChatHub.ChatConnection;

public class Connections<T> where T : Hub
{
    public ConcurrentDictionary<string, HubCallerContext> All { get; } = new();
}