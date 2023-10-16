using AutoMapper;
using DataClass.DTOs;
using DataClass.Enums;
using DataClass.Models;
using DataService;

namespace Core.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageLogDataService _messageLogService;

        private readonly IMapper _mapper;

        public MessageService(IMessageLogDataService messageLogService, IMapper mapper)
        {
            _mapper = mapper;
            _messageLogService = messageLogService;
        }

        public async Task<GetMessageLogListByIdRangeResponse> GetMessageLogListAsync(GetMessageLogListByIdRangeRequest request)
        {
             List<MessageLogModel> result;

            if(request.QueryModeType == QueryModeType.NewMessage)
            {
                result = await _messageLogService.GetNewMessageListAsync(request.ChatroomId, request.MessageId, request.MaxCount);
                result = result.OrderBy(x => x.Id).ToList();
            }
            else{
                result = await _messageLogService.GetHistoryMessageListAsync(request.ChatroomId, request.MessageId, request.MaxCount);
            }

            return new GetMessageLogListByIdRangeResponse()
            {
                MaxMessageId = result.Any() ? result.Max(x => x.Id) : 0,
                MixMessageId =  result.Any() ? result.Min(x => x.Id) : 0,
                MessageLogs = result,
                Count = result.Count 
            };
        }

        public async Task<GetMessageLogTotalCountResponse> GetMessageLogTotalCountAsync(GetMessageLogTotalCountRequest getMessageLogTotalCountRequest)
        {
            return new GetMessageLogTotalCountResponse()
            {
                TotalCount = await _messageLogService.GetMessageLogTotalCountByGroupIdAsync(getMessageLogTotalCountRequest.GroupId)
            };
        }

        public async Task<long> ReceiveMessageProcessAsync(ReceiveMessageProcessRequest receiveMessageProcessRequest)
        {
            return await _messageLogService.CreateMessageLogAsync(receiveMessageProcessRequest);
        } 
    }
}