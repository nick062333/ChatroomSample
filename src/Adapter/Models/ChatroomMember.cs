﻿namespace Adapter.Models
{
    /// <summary>
    /// 聊天室成員
    /// </summary>
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
        /// 進入時間
        /// </summary>
        public DateTime EntryTime { get; set; }

        /// <summary>
        /// 最後登入時間
        /// </summary>
        public DateTime LastLoginTime { get; set; }
    }
}
