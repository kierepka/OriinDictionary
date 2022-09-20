using System.Text.Json.Serialization;

namespace OriinDictionary7.Models;

public record Change
{
    [JsonPropertyName("after")]
    // ReSharper disable once UnusedMember.Global
    public BaseTerm After { get; set; } = new();

    [JsonPropertyName("before")]
    // ReSharper disable once UnusedMember.Global
    public BaseTerm Before { get; set; } = new();

    public Change()
    {

    }
}
