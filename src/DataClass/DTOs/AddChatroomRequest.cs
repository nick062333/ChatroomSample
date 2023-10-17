namespace DataClass.DTOs
{
    public class AddChatroomRequest
    {
        /// <summary>
        /// 發送者
        /// </summary>
        /// <value></value>
        public long UserId { get; set; }

        /// <summary>
        /// 接收者
        /// </summary>
        /// <value></value>
        public long ToUserId {get;set; }
    }
}