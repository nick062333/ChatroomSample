namespace webapi.Models
{
    /// <summary>
    /// 接收訊息
    /// </summary>
    /// <param name="Message">訊息</param>
    /// <param name="SendDate">接收時間</param>
    public record NotificationRequest(string Message, DateTime SendDate);
}