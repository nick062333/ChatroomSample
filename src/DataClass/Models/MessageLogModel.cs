namespace DataClass.Models
{
    public class MessageLogModel
    {
        public long Id { get; set; }

        public string GroupId { get; set; }
        
        public int Status { get; set; }

        public required string Message { get; set; }

        public long SendUserId { get; set; }

        public DateTime SendTime { get; set; }
    }
}