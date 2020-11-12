using System;
using System.Text.Json.Serialization;

namespace OriinDic.Models
{
    public class BaseTermLastEdit
    {
        [JsonPropertyName("id")]
        public long Id { get; set; } = long.MinValue;

        [JsonPropertyName("object_type")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string ObjectType { get; set; } = string.Empty;

        [JsonPropertyName("object_id")]
        public long ObjectId { get; set; } = long.MinValue;

        [JsonPropertyName("action")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Action { get; set; } = string.Empty;

        [JsonPropertyName("date")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DateTimeOffset Date { get; set; } = DateTime.Now;

        [JsonPropertyName("user")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public User User { get; set; } = new User();

        [JsonPropertyName("change")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public BaseTermChange Change { get; set; } = new BaseTermChange();
    }
}