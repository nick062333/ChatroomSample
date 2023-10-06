using DataService.Models.Message;

namespace DataService
{
    public interface IMessageLogService
    {
        public Task CreateMessageLogAsync(CreateMessageLogModel createMessageLogModel);
    }
}
