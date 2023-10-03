using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using webapi.Models;

namespace webapi.Hubs
{
public class NotificationHub : Hub
{
    public Task NotifyAll(Notification notification) =>
        Clients.All.SendAsync("NotificationReceived", notification);
}
}