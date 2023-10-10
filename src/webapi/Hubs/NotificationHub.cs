using Core;
using DataClass.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using webapi.Models;

namespace webapi.Hubs
{
    public class NotificationHub : Hub<INotificationClient>
    {
        // private readonly ILogger<NotificationHub> _logger;

        private readonly IChatService _chatService;

        public NotificationHub(IChatService chatService) {
            _chatService = chatService;
        }

        [Authorize]
        [HubMethodName("send")]
        public async Task SendMessage(NotificationRequest notification)
        {
            var httpContext = Context!.GetHttpContext();
            string groupId = httpContext.Request.Query["GroupName"].ToString();
            string userId = Context.User!.Identity!.Name!;

            await _chatService.ReceiveMessageProcessAsync(new ReceiveMessageProcessRequest(
                    groupId,
                    0, 
                    notification.Message,
                    notification.SendDate
                ));

            await Clients
                .Group(httpContext.Request.Query["GroupName"].ToString())
                .ReceiveMessage(Context.User!.Identity!.Name!, notification.Message, DateTime.Now.AddHours(8));
        }
    }
}