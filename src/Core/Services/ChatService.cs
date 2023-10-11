using AutoMapper;
using DataClass.DTOs;
using DataService;

namespace Core.Services
{
    public class ChatService : IChatService
    {
        private readonly IMessageLogDataService _messageLogService;
        private readonly IMapper _mapper;

        public ChatService(IMessageLogDataService messageLogService, IMapper mapper)
        {
            _mapper = mapper;
            _messageLogService = messageLogService;
        }

        public Task<List<ChatMessageResponse>> GetChatMessageList(string groupName)
        {
            throw new NotImplementedException();
        }

        public async Task<GetMessageLogListResponse> GetMessageLogListAsync(GetMessageLogListRequest getMessageLogListRequest)
        {
            var messageLogs = await _messageLogService.GetMessageLogListAsync(getMessageLogListRequest);
            return new GetMessageLogListResponse()
            {
                MessageLogs = messageLogs
            };
        }

        public async Task ReceiveMessageProcessAsync(ReceiveMessageProcessRequest receiveMessageProcessRequest)
        {
            //新增訊息至資料庫
            await _messageLogService.CreateMessageLogAsync(receiveMessageProcessRequest);
        }
    }
}
