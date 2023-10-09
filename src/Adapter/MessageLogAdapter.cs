using Adapter.DBModel;

namespace Adapter
{
    public interface IMessageLogAdapter 
    {
        public Task InsertMessageLog(MessageLog messageLog);
    }
}