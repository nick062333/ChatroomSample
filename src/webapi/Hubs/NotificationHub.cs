using System.Security.Claims;
using Core;
using DataClass.DTOs;
using DataClass.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Utility;
using webapi.Models;

namespace webapi.Hubs
{
    public class NotificationHub : Hub<INotificationClient>
    {
        private readonly IMessageService _messageService;

        public NotificationHub(IMessageService messageService) {
            _messageService = messageService;
        }

        [Authorize]
        [HubMethodName("send")]
        public async Task SendMessage(NotificationRequest notification)
        {
            var httpContext = Context!.GetHttpContext();

            if (!Guid.TryParse(httpContext.Request.Query["GroupId"].ToString(), out Guid groupId))
                throw new Exception($"groupId not guid:{Context.User!.Identity!.Name ?? string.Empty}");

            if(!long.TryParse(Context.User!.Identity!.Name, out long userId))
                throw new Exception($"user id not number! userId:{Context.User!.Identity!.Name ?? string.Empty}");

            await _messageService.ReceiveMessageProcessAsync(new ReceiveMessageProcessRequest(
                    groupId,
                    userId, 
                    notification.Message,
                    notification.SendTime
                ));

            var identity = (ClaimsIdentity)Context.User.Identity;
            var userName = identity?.FindFirst(ClaimTypes.Name)?.Value ?? string.Empty;

            await Clients
                .Group(groupId.ToString())
                .ReceiveMessage(userName, notification.Message, TwDateTime.Now, MessageLogStatus.Enable);
        }
    }
}