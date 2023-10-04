using System.Text.Json.Serialization;

namespace webapi.Models
{

    public class LoginModel{

        [JsonPropertyName("account")]
        public  string Account { get; set; } = string.Empty;

        [JsonPropertyName("password")]

        public string Password { get; set; } = string.Empty;
    }
}