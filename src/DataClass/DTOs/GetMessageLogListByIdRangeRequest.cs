using DataClass.Enums;

namespace DataClass.DTOs
{
    public class GetMessageLogListByIdRangeRequest
    {
        public Guid ChatroomId { get; set; }

        public long MessageId { get; set; }
        
        public QueryModeType QueryModeType { get; set; }

        public int MaxCount { get; set; }
    }
}
