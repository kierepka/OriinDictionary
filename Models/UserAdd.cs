using System.Text.Json.Serialization;

namespace OriinDic.Models
{
    public class UserAdd
    {
        [JsonPropertyName("username")]
        public string UserName { get; set; } = string.Empty;
        [JsonPropertyName("password")]
        public string Password { get; set; } = string.Empty;
        [JsonPropertyName("first_name")]
        public string FirstName { get; set; } = string.Empty;
        [JsonPropertyName("last_name")]
        public string LastName { get; set; } = string.Empty;
        [JsonPropertyName("email")]
        public string Email { get; set; } = string.Empty;

        public UserAdd()
        {
            
        }
    }
}