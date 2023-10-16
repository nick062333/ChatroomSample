using Adapter.Models;

namespace Adapter.Interfaces
{
    public interface IMessageLogAdapter
    {
        Task<int> GetMessageLogTotalCountByGroupIdAsync(Guid groupId);

        Task<long> InsertMessageLogAsync(MessageLog messageLog);

        Task<IEnumerable<MessageLog>> GetNewMessageListAsync(Guid groupId, long startMessageId, int pageNumber, int pageSize);
        
        Task<int> GetNewMessageListCountAsync(Guid groupId, long startMessageId);

        Task<IEnumerable<MessageLog>> GetHistoryMessageListAsync(Guid groupId, long endMessageId, int pageNumber, int pageSize);

        Task<int> GetHistoryMessageListCountAsync(Guid groupId, long startMessageId);

    }
}