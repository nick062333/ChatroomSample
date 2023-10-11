namespace Adapter.Models
{
    public class MessageLog
    {
        public long Id { get; set; }

        public string GroupId { get; set; }
        
        public int Status { get; set; }

        public string Message { get; set; }

        public long SendUserId { get; set; }

        public DateTime SendTime { get; set; }
    }
}
