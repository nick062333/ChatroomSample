using Microsoft.AspNetCore.SignalR;
using webapi.Models;

namespace webapi.Hubs
{
    public class NotificationHub : Hub<INotificationClient>
    {
        [HubMethodName("send")]
        public async Task SendMessage(NotificationRequest notification)
        {
            await Clients
                .All
                // .User(notification.UserId)
                .ReceiveMessage(notification.UserId, notification.Message, DateTime.Now.AddHours(8));
        }

        public async Task AddToGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
            //await Clients.Group(groupName).SendAsync("Send", $"{Context.ConnectionId} has joined the group {groupName}.");
        }
    }
}