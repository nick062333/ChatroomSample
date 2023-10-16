using DataClass.DTOs;
using DataClass.Models;

namespace DataService
{
    public interface IMessageLogDataService
    {
        public Task<long> CreateMessageLogAsync(ReceiveMessageProcessRequest receiveMessageProcessRequest);

        public Task<int> GetMessageLogTotalCountByGroupIdAsync(Guid groupId);

        public Task<List<MessageLogModel>> GetNewMessageListAsync(Guid groupId, long startMessageId, int maxCount);

        public Task<List<MessageLogModel>> GetHistoryMessageListAsync(Guid groupId, long endMessageId, int maxCount);
    }
}
