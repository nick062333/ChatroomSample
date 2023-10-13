using DataClass.DTOs;
using DataClass.Models;
using System;

namespace DataService
{
    public interface IMessageLogDataService
    {
        public Task CreateMessageLogAsync(ReceiveMessageProcessRequest receiveMessageProcessRequest);

        public Task<List<MessageLogModel>> GetMessageLogListAsync(GetMessageLogListRequest getMessageLogListRequest);

        public Task<int> GetMessageLogTotalCountByGroupIdAsync(Guid groupId);
    }
}
