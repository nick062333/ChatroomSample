namespace Adapter.DBModel
{
    public class MessageLog
    {
        public long Id { get; set; }

        public long ChatroomId { get; set; }
        
        public int Status { get; set; }

        public required string Content { get; set; }

        public long SendUserId { get; set; }

        /// <summary>
        /// 傳遞給哪些使用者
        /// </summary>
        public long ToUserId { get;set; }

        public DateTime SendTime { get; set; }
    }
}
