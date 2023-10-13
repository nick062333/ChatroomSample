using Adapter.Models;

namespace Adapter.Interfaces
{
    public interface IMessageLogAdapter
    {
        Task<IEnumerable<MessageLog>> GetMessageLogListAsync(Guid groupId, int startIndex, int pageSize);

        Task<int> GetMessageLogTotalCountByGroupIdAsync(Guid groupId);

        Task InsertMessageLogAsync(MessageLog messageLog);

        Task<IEnumerable<MessageLog>> GetMessageLogListByIdRangeAsync(Guid groupId, int startId, int pageNumber, int pageSize);

        Task<int> GetMessageLogListByIdRangeCountAsync(Guid groupId, int startId);
    }
}