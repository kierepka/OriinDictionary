using System.Text.Json.Serialization;

namespace OriinDictionary7.Models;

public record BaseTermChange
{
    [JsonPropertyName("after")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public BaseTerm After { get; set; } = new();

    [JsonPropertyName("before")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public BaseTerm Before { get; set; } = new();

    public BaseTermChange()
    {

    }
}