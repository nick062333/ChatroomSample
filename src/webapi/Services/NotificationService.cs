using Microsoft.AspNetCore.SignalR;
using webapi.Hubs;
using webapi.Models;

namespace webapi.Services
{
    public class NotificationService
    {
        private readonly IHubContext<NotificationHub> _hubContext;

        public NotificationService(IHubContext<NotificationHub> hubContext) =>
            _hubContext = hubContext;

        public Task SendNotificationAsync(NotificationRequest notification) =>
            notification is not null
                ? _hubContext.Clients.All.SendAsync("NotificationReceived", notification)
                : Task.CompletedTask;
    }
}