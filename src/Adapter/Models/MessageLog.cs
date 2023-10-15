namespace Adapter.Models
{
    /// <summary>
    /// 訊息
    /// </summary>
    public class MessageLog
    {
        public long Id { get; set; }

        public Guid GroupId { get; set; }
        
        public int Status { get; set; }

        public string Message { get; set; }

        public long SendUserId { get; set; }

        public DateTime SendTime { get; set; }

        public string UserName { get; set; }
    }
}
