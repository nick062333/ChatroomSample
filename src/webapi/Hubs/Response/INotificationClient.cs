namespace webapi.Models
{
    public interface INotificationClient
    {
        Task ReceiveMessage(string userName, string message, DateTime sendDate);
    }
}
