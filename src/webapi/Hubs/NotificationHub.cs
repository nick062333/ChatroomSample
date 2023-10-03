using Microsoft.AspNetCore.SignalR;
using webapi.Models;

namespace webapi.Hubs
{
    public class NotificationHub : Hub<IChatClient>
    {
        [HubMethodName("send")]
        public async Task SendMessage(NotificationRequest notification)
        {
            await Clients
                .User(notification.UserId)
                .ReceiveMessage(notification.UserId, DateTime.Now.AddHours(8));
        }
    }
}