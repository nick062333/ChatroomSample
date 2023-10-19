using MediatR;
using Microsoft.AspNetCore.SignalR;
using webapi.Hubs;

namespace webapi.Events
{
    /// <summary>
    /// 發送未讀訊息提醒
    /// </summary>
    /// <param name="chatroomRemindHub"></param>
    public class ChatroomRemindNoticeSendEventHandler(IHubContext<ChatroomRemindHub> chatroomRemindHub) : INotificationHandler<ChatroomRemindNoticeSendEvent>
    {
        private readonly IHubContext<ChatroomRemindHub> _chatroomRemindHub = chatroomRemindHub;

        [HubMethodName("send")]
        public async Task Handle(ChatroomRemindNoticeSendEvent notification, CancellationToken cancellationToken)
        {
            await _chatroomRemindHub.Clients.Groups(notification.ChatroomId.ToString()).SendAsync("", cancellationToken);
        }
    }
}
