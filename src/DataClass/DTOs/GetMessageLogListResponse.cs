using DataClass.Models;

namespace DataClass.DTOs
{
    public class GetMessageLogListResponse
    {
        public List<MessageLogModel> MessageLogs { get; set; }
    }
}