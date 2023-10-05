using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using webapi.Models;

namespace webapi.Hubs
{
    public class NotificationHub : Hub<INotificationClient>
    {

        [Authorize]
        [HubMethodName("send")]
        public async Task SendMessage(NotificationRequest notification)
        {
            var httpContext = Context!.GetHttpContext();
            
            await Clients
                .Group(httpContext.Request.Query["GroupName"].ToString())
                .ReceiveMessage(Context.User!.Identity!.Name!, notification.Message, DateTime.Now.AddHours(8));
        }
    }
}