using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DataClass.DTOs;
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
            await _messageLogService.CreateMessageLogAsync(receiveMessageProcessRequest);
        } 
    }
}