using System.Text.Json.Serialization;

namespace OriinDictionary7.Models;

public record Comment : CommentAdd
{
    [JsonPropertyName("user")]
    public User User { get; set; } = new();

    [JsonPropertyName("id")]
    public long Id { get; set; } = 0;

    [JsonPropertyName("date")]
    public DateTimeOffset Date { get; set; } = DateTime.Now;

    public Comment()
    {

    }
}
