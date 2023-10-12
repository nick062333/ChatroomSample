using DataClass.Enums;

namespace DataClass.Models
{
    public class MessageLogModel
    {
        public long Id { get; set; }

        public Guid GroupId { get; set; }
        
        public MessageLogStatus Status { get; set; }

        public required string Message { get; set; }

        public long SendUserId { get; set; }

        public DateTime SendTime { get; set; }

        public string UserName { get; set; }
    }
}