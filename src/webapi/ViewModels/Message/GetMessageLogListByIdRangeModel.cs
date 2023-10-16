using System.Text.Json.Serialization;
using DataClass.Enums;

namespace webapi.ViewModels.Message
{
    public class GetMessageLogListByIdRangeModel
    {
        [JsonPropertyName("chatroomId")]
        public Guid ChatroomId { get; set; }

        [JsonPropertyName("messageId")]
        public long MessageId { get; set; }
        
        [JsonPropertyName("queryModeType")]
        public QueryModeType QueryModeType { get; set; }
    }
}