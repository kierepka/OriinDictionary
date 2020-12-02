using System.Text.Json.Serialization;

namespace OriinDic.Models
{
    public class Token
    {
        [JsonPropertyName("auth_token")]
        public string AuthToken { get; } = string.Empty;
    }
}