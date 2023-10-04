namespace webapi.Models
{
    public interface IChatClient
    {
        Task ReceiveMessage(string userName, string message, DateTime sendDate);
    }
}
