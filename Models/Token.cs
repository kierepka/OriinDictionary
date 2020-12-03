using System.Text.Json.Serialization;

namespace OriinDic.Models
{
    public record Token
    {
        [JsonPropertyName("auth_token")]
        public string AuthToken { get; set; } = string.Empty;
    }
}