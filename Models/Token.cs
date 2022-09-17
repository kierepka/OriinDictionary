using System.Text.Json.Serialization;

namespace OriinDictionary7.Models;

public record Token
{
    [JsonPropertyName("auth_token")]
    public string AuthToken { get; set; } = string.Empty;
}