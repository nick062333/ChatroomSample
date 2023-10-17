namespace DataClass.Models
{
    public class ChatroomMemberModel
    {
        /// <summary>
        /// 聊天室代碼
        /// </summary>
        public Guid ChatroomId { get; set; }

        /// <summary>
        /// 使用者id
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// 進入時間
        /// </summary>
        public DateTime EntryTime { get; set; }

        /// <summary>
        /// 使用者名稱
        /// </summary>
        /// <value></value>
        public string UserName { get; set; }

        /// <summary>
        /// 最後登入時間
        /// </summary>
        public DateTime LastLoginTime { get; set; }
    }
}