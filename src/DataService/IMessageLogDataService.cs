using Adapter.Models;
using DataClass.DTOs;

namespace DataService
{
    public interface IMessageLogDataService
    {
        public Task CreateMessageLogAsync(ReceiveMessageProcessRequest receiveMessageProcessRequest);

        public Task<List<MessageLogModel>> GetMessageLogListAsync(GetMessageLogListRequest getMessageLogListRequest);
    }
}
