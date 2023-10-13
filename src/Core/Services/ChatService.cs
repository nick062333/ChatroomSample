using Adapter.Models;
using AutoMapper;
using DataClass.DTOs;
using DataService;
using Microsoft.VisualBasic;

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

        public async Task<GetMessageLogListResponse> GetMessageLogListAsync(GetMessageLogListRequest getMessageLogListRequest)
        {
            var messageLogs = await _messageLogService.GetMessageLogListAsync(getMessageLogListRequest);
            
            return new GetMessageLogListResponse()
            {
                MessageLogs = messageLogs
            };
        }

        public async Task<GetMessageLogListByIdRangeRequest> GetMessageLogListByIdRangeAsync(Guid groupId, int startId)
        {
            var messageLogs = await _messageLogService.GetMessageLogListByIdRangeAsync(groupId, startId);

            return new GetMessageLogListByIdRangeRequest()
            {
                MessageLogs = messageLogs
            };
        }

        public async Task<GetMessageLogTotalCountResponse> GetMessageLogTotalCountAsync(GetMessageLogTotalCountRequest getMessageLogTotalCountRequest)
        {
            return new GetMessageLogTotalCountResponse()
            {
                TotalCount = await _messageLogService.GetMessageLogTotalCountByGroupIdAsync(getMessageLogTotalCountRequest.GroupId)
            };
        }

        public async Task ReceiveMessageProcessAsync(ReceiveMessageProcessRequest receiveMessageProcessRequest)
        {
            //新增訊息至資料庫
            await _messageLogService.CreateMessageLogAsync(receiveMessageProcessRequest);
        }
    }
}
