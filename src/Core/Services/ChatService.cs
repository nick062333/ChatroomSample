using Core.Models.Chat;

namespace Core.Services
{
    public class ChatService : IChatService
    {
        public ChatService()
        {

        }

        public Task<List<ChatMessageResponse>> GetChatMessageList(string groupName)
        {
            throw new NotImplementedException();
        }

        public async Task ReceiveMessageProcessAsync(ReceiveMessageProcessRequest receiveMessageProcessRequest)
        {
            //新增至資料庫

            await Task.CompletedTask;
        }
    }
}
