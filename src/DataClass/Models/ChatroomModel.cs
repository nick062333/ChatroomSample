namespace DataClass.Models
{
    public class ChatroomModel
    {
        /// <summary>
        /// 聊天室代碼
        /// </summary>
        public required string ChatroomId { get; set; }

        /// <summary>
        /// 使用者id
        /// </summary>
        public required string UserId { get; set; }

        /// <summary>
        /// 最後登入時間
        /// </summary>
        public DateTime LastLoginTime { get; set; }
    }
}