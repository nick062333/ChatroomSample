using DataClass.DTOs;

namespace DataService
{
    public interface IMessageLogDataService
    {
        public Task CreateMessageLogAsync(ReceiveMessageProcessRequest receiveMessageProcessRequest);
    }
}
