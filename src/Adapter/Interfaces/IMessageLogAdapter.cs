using Adapter.Models;

namespace Adapter.Interfaces
{
    public interface IMessageLogAdapter
    {
        Task<IEnumerable<MessageLog>> GetMessageLogListAsync(Guid groupId, int startIndex, int pageSize);

        Task<int> GetMessageLogTotalCountByGroupIdAsync(Guid groupId);

        public Task InsertMessageLog(MessageLog messageLog);
    }
}