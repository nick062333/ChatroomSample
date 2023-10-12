namespace DataClass.DTOs
{
    public class ReceiveMessageProcessRequest
    {
        public ReceiveMessageProcessRequest(string groupId, long userId, string message, DateTime sendTime)
        {
            GroupId = groupId;
            UserId = userId;
            Message = message;
            SendTime = sendTime;
        }

        /// <summary>
        /// 群組代碼
        /// </summary>
        public string GroupId { get; set; }

        /// <summary>
        /// 使用者代碼
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// 訊息內容
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 訊息發送時間
        /// </summary>
        public DateTime SendTime { get; set; }
    }
}
