using System.Text.Json.Serialization;

namespace webapi.ViewModels.Chatroom
{
    public class AddChatroomModel
    {
        [JsonPropertyName("toUserId")]
        public long ToUserId {get;set; }
    }
}