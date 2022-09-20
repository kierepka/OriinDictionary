using System.Text.Json.Serialization;

namespace OriinDictionary7.Models;

public record ResultBaseTranslation
{
    [JsonPropertyName("base_term")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public BaseTerm? BaseTerm { get; set; }

    [JsonPropertyName("translation")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Translation? Translation { get; set; }

    [JsonPropertyName("translations")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // ReSharper disable once CollectionNeverQueried.Global
    public List<Translation>? Translations { get; set; }

    public ResultBaseTranslation()
    {

    }
}