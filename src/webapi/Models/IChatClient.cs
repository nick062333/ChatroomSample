namespace webapi.Models
{
    public interface IChatClient
    {
        Task ReceiveMessage(string message, DateTime SendDate);
    }
}
