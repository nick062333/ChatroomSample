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
        public async Task send( string message)
        {
            Console.WriteLine(message);

            await Clients.All.SendAsync("ReceiveMessage", $"is ok! ({message})");
        }

        public  Task NotifyAll(Notification notification) =>
            Clients.All.SendAsync("NotificationReceived", notification);
}
}