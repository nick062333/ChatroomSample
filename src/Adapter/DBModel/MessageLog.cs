namespace Adapter.DBModel
{
    public class Message
    {
        public long Id { get; set; }

        public long ChatroomId { get; set; }
        
        public int Status { get; set; }

        public required string Content { get; set; }

        public long SendUserId { get; set; }

        public long ToUserId { get;set; }

        public DateTime SendTime { get; set; }
    }
}
