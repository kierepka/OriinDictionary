using System.Text.Json.Serialization;

namespace OriinDictionary7.Models;

public record RootObject<T>
{
    [JsonPropertyName("pages")]
    // ReSharper disable once UnusedAutoPropertyAccessor.Global
    public long Pages { get; set; }
    [JsonPropertyName("count")]
    // ReSharper disable once UnusedAutoPropertyAccessor.Global
    public int Count { get; set; }
    [JsonPropertyName("current_page")]
    // ReSharper disable once UnusedMember.Global
    public long CurrentPage { get; set; }
    [JsonPropertyName("results")]
    // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Global
    public List<T> Results { get; set; }
    public RootObject()
    {
        Results = new List<T>();
    }
}