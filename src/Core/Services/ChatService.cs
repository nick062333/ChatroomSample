using DataClass.DTOs;
using DataService;
using DataService.Service;

namespace Core.Services
{
    public class ChatService : IChatService
    {
        private readonly IMessageLogDataService _messageLogService;

        public ChatService(IMessageLogDataService messageLogService)
        {
            _messageLogService = messageLogService;
        }

        public Task<List<ChatMessageResponse>> GetChatMessageList(string groupName)
        {
            throw new NotImplementedException();
        }

        public async Task ReceiveMessageProcessAsync(ReceiveMessageProcessRequest receiveMessageProcessRequest)
        {
            //新增訊息至資料庫
            await _messageLogService.CreateMessageLogAsync(receiveMessageProcessRequest);
        }
    }
}
