using System.Security.Claims;
using Core;
using DataClass.DTOs;
using DataClass.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Utility;
using webapi.Events;
using webapi.Models;

namespace webapi.Hubs
{
    public class NotificationHub : Hub<INotificationClient>
    {
        private readonly IMessageService _messageService;
        private readonly IMediator _mediator;

        public NotificationHub(IMessageService messageService, IMediator mediator) {
            _messageService = messageService;
            _mediator = mediator;
        }

        [Authorize]
        [HubMethodName("send")]
        public async Task SendMessageAsync(NotificationRequest notification)
        {
            var httpContext = Context!.GetHttpContext();

            if (!Guid.TryParse(httpContext.Request.Query["GroupId"].ToString(), out Guid groupId))
                throw new Exception($"groupId not guid:{Context.User!.Identity!.Name ?? string.Empty}");

            if(!long.TryParse(Context.User!.Identity!.Name, out long userId))
                throw new Exception($"user id not number! userId:{Context.User!.Identity!.Name ?? string.Empty}");

            var messageId = await _messageService.ReceiveMessageProcessAsync(new ReceiveMessageProcessRequest(
                    groupId,
                    userId, 
                    notification.Message,
                    notification.SendTime
                ));

            var identity = (ClaimsIdentity)Context.User.Identity;
            var userName = identity?.FindFirst(ClaimTypes.Name)?.Value ?? string.Empty;

            await Clients
                .Group(groupId.ToString())
                .ReceiveMessage(userName, messageId, notification.Message, TwDateTime.Now, MessageLogStatus.Enable);

            await _mediator.Send(new ChatroomRemindNoticeSendEvent(groupId, userId, messageId));
        }
    }
}