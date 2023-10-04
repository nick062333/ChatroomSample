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
                .All
                // .User(notification.UserId)
                .ReceiveMessage(notification.UserId, notification.Message, DateTime.Now.AddHours(8));
        }
    }
}