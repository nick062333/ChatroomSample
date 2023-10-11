using Adapter.Models;

namespace Adapter.Interfaces
{
    public interface IMessageLogAdapter
    {
        Task<IEnumerable<MessageLog>> GetMessageLogListAsync(string groupId, int page, int pageSize);

        public Task InsertMessageLog(MessageLog messageLog);
    }
}