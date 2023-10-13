using System.Text.Json.Serialization;

namespace webapi.ViewModels.Message
{
    public class GetMessageLogListViewModel
    {
        [JsonPropertyName("groupId")]
        public Guid GroupId { get; set; }

        [JsonPropertyName("startIndex")]

        public int StartIndex { get; set; } 

        [JsonPropertyName("pageSize")]
        public int PageSize { get; set; } 
    }
}