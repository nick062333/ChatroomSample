using Microsoft.AspNetCore.SignalR;
using webapi.Hubs.Request;
using webapi.Hubs.Response;

namespace webapi.Hubs
{
    public class ChatroomRemindHub : Hub<ChatroomRemindMessageResponse>
    {
        public ChatroomRemindHub() { }

        [HubMethodName("send")]
        public async Task SendMessageAsync(ChatroomRemindMessageRequest chatroomRemindMessageRequest)
        {
            await Task.CompletedTask;
        }
    }
}
