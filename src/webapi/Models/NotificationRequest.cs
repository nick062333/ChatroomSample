namespace webapi.Models
{
    public record NotificationRequest(string UserId, string Message, DateTime Date);
}