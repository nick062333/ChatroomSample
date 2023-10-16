using DataClass.Enums;

namespace webapi.Models
{
    public interface INotificationClient
    {
        /// <summary>
        /// Client端接收訊息
        /// </summary>
        /// <param name="userName">使用者名稱</param>
        /// <param name="messageId">訊息流水號</param>
        /// <param name="message">訊息</param>
        /// <param name="sendDate">發送時間</param>
        /// <param name="Status">訊息狀態</param>
        /// <returns></returns>
        Task ReceiveMessage(string userName, long messageId, string message, DateTime sendDate, MessageLogStatus Status);
    }
}
