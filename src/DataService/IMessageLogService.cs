using DataClass.DTOs;

namespace DataService
{
    public interface IMessageLogService
    {
        public Task CreateMessageLogAsync(ReceiveMessageProcessRequest receiveMessageProcessRequest);
    }
}
