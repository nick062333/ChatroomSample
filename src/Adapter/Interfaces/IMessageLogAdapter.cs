using Adapter.Models;

namespace Adapter.Interfaces
{
    public interface IMessageLogAdapter
    {
        public Task InsertMessageLog(MessageLog messageLog);
    }
}