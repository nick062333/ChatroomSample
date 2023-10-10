namespace Adapter.Models
{
    public class MessageLog
    {
        public long Id { get; set; }

        public long ChatroomId { get; set; }
        
        public int Status { get; set; }

        public required string Content { get; set; }

        public long SendUserId { get; set; }

        public DateTime SendTime { get; set; }
    }
}
