using DataClass.Models;

namespace DataClass.DTOs
{
    public class GetMessageLogListByIdRangeResponse
    {
        public List<MessageLogModel> MessageLogs { get; set; }

        public long MixMessageId { get; set; }

        public long  MaxMessageId { get; set; }

        public int Count { get; set; }
    }
}