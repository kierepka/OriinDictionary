using System.Text.Json.Serialization;

namespace OriinDictionary7.Models;

public record User : UserUpdate
{
    [JsonPropertyName("id")]
    public long Id { get; set; }
    [JsonPropertyName("is_superuser")]
    public bool IsSuperuser { get; set; }

    public User()
    {

    }
}