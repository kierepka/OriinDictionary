using System;
using System.Text.Json.Serialization;

namespace OriinDic.Models
{
    public class TranslationApproval
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("object_type")]
        public string ObjectType { get; set; }

        [JsonPropertyName("object_id")]
        public long ObjectId { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; }

        [JsonPropertyName("date")]
        public DateTimeOffset Date { get; set; }

        [JsonPropertyName("user")]
        public User User { get; set; }

        [JsonPropertyName("change")]
        public Change Change { get; set; }
    }
}