namespace webapi.Models
{
    public interface INotificationClient
    {
        /// <summary>
        /// Client端接收訊息
        /// </summary>
        /// <param name="userName">使用者名稱</param>
        /// <param name="message">訊息</param>
        /// <param name="sendDate">發送時間</param>
        /// <returns></returns>
        Task ReceiveMessage(string userName, string message, DateTime sendDate);
    }
}
