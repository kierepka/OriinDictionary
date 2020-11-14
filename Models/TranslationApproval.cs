using System;
using System.Text.Json.Serialization;

namespace OriinDic.Models
{
    public class TranslationApproval
    {
        [JsonPropertyName("id")]
        public long Id { get; set; } = 0;

        [JsonPropertyName("object_type")]
        public string ObjectType { get; set; } = string.Empty;

        [JsonPropertyName("object_id")]
        public long ObjectId { get; set; } = 0;

        [JsonPropertyName("action")]
        public string Action { get; set; } = string.Empty;

        [JsonPropertyName("date")]
        public DateTimeOffset Date { get; set; } = DateTime.Now;

        [JsonPropertyName("user")]
        public User User { get; set; } = new User();

        [JsonPropertyName("change")]
        public Change Change { get; set; } = new Change();
    }
}