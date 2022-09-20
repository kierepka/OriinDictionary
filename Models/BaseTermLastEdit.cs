using System.Text.Json.Serialization;

namespace OriinDictionary7.Models;

public record BaseTermLastEdit
{
    [JsonPropertyName("id")]
    // ReSharper disable once UnusedMember.Global
    public long Id { get; set; } = 0;

    [JsonPropertyName("object_type")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // ReSharper disable once UnusedMember.Global
    public string ObjectType { get; set; } = string.Empty;

    [JsonPropertyName("object_id")]
    // ReSharper disable once UnusedMember.Global
    public long ObjectId { get; set; } = 0;

    [JsonPropertyName("action")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // ReSharper disable once UnusedMember.Global
    public string Action { get; set; } = string.Empty;

    [JsonPropertyName("date")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    // ReSharper disable once UnusedMember.Global
    public DateTimeOffset Date { get; set; } = DateTime.Now;

    [JsonPropertyName("user")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Global
    public User User { get; set; } = new();

    [JsonPropertyName("change")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // ReSharper disable once UnusedMember.Global
    public BaseTermChange? Change { get; set; }

    public BaseTermLastEdit()
    {

    }
}