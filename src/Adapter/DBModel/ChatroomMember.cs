namespace Adapter.DBModel
{
    public class ChatroomMember
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
        /// 入場時間
        /// </summary>
        public DateTime EntryTime { get; set; }
    }
}
