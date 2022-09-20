using System.Text.Json.Serialization;

namespace OriinDictionary7.Models;

// ReSharper disable once ClassNeverInstantiated.Global
public record TranslationChange
{
    [JsonPropertyName("after")]
    // ReSharper disable once UnusedMember.Global
    public Translation After { get; set; } = new();

    [JsonPropertyName("before")]
    // ReSharper disable once UnusedMember.Global
    public Translation Before { get; set; } = new();

    public TranslationChange()
    {

    }
}