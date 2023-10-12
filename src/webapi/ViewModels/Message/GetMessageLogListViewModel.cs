using System.Text.Json.Serialization;

namespace webapi.ViewModels.Message
{
    public class GetMessageLogListViewModel
    {
        [JsonPropertyName("groupId")]
        public Guid GroupId { get; set; }

        [JsonPropertyName("page")]

        public int Page { get; set; } 

        [JsonPropertyName("pageSize")]
        public int PageSize { get; set; } 
    }
}