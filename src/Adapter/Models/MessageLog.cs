namespace Adapter.Models
{
    public class MessageLog
    {
        public long Id { get; set; }

        public string ChatroomId { get; set; }
        
        public int Status { get; set; }

        public required string Message { get; set; }

        public long SendUserId { get; set; }

        public DateTime SendTime { get; set; }
    }
}
