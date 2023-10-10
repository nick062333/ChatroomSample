using System.Text.Json.Serialization;

namespace webapi.ViewModels.Auth
{

    public class LoginViewModel{

        [JsonPropertyName("account")]
        public  string Account { get; set; } = string.Empty;

        [JsonPropertyName("password")]

        public string Password { get; set; } = string.Empty;
    }
}