using System.Text.Json.Serialization;

namespace webapi.ViewModels.Chatroom
{
    public class AddChatroomModel
    {
        [JsonPropertyName("userId")]
        public long UserId { get; set; }
    }
}