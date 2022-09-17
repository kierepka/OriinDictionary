using System.Text.Json.Serialization;

namespace OriinDictionary7.Models;

public record CommentAdd
{
    [JsonPropertyName("translation_id")]
    public long TranslationId { get; set; }
    [JsonPropertyName("text")]
    public string Text { get; set; } = string.Empty;

    public CommentAdd()
    {

    }
}