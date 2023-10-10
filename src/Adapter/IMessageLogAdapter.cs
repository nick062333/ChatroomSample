using Adapter.Models;

namespace Adapter
{
    public interface IMessageLogAdapter 
    {
        public Task InsertMessageLog(MessageLog messageLog);
    }
}