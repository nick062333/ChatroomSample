namespace webapi.Models
{
    /// <summary>
    /// �����T��
    /// </summary>
    /// <param name="Message">�T��</param>
    /// <param name="SendDate">�����ɶ�</param>
    public record NotificationRequest(string Message, DateTime SendDate);
}