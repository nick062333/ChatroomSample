using Core;
using DataClass.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Utility;
using webapi.Models;

namespace webapi.Hubs
{
    public class NotificationHub : Hub<INotificationClient>
    {
        private readonly IChatService _chatService;

        public NotificationHub(IChatService chatService) {
            _chatService = chatService;
        }

        [Authorize]
        [HubMethodName("send")]
        public async Task SendMessage(NotificationRequest notification)
        {
            var httpContext = Context!.GetHttpContext();

            string groupId = httpContext.Request.Query["GroupId"].ToString();

            if(!long.TryParse(Context.User!.Identity!.Name, out long userId))
                throw new Exception($"user id not number! userId:{Context.User!.Identity!.Name ?? string.Empty}");

            await _chatService.ReceiveMessageProcessAsync(new ReceiveMessageProcessRequest(
                    groupId,
                    userId, 
                    notification.Message,
                    notification.SendDate
                ));

            await Clients
                .Group(groupId)
                .ReceiveMessage(Context.User!.Identity!.Name!, notification.Message, TwDateTime.Now);
        }
    }
}