using System.Text.Json.Serialization;

namespace DataClass.DTOs
{
    public class ValidateUserResponse
    {
        public ValidateUserResponse(string token, long userId, string userName)
        {
            Token = token;
            UserId = userId;
            UserName = userName;
        }

        [JsonPropertyName("token")]
        public string Token { get; set; }

        [JsonPropertyName("userId")]
        public long UserId { get; set; }

        [JsonPropertyName("userName")]
        public string UserName { get; set; }
    }
}