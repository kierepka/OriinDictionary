using System;
using System.Text.Json.Serialization;

namespace OriinDic.Models
{
    public record TranslationApproval
    {
        [JsonPropertyName("id")]
        // ReSharper disable once UnusedMember.Global
        public long Id { get; set; } = 0;

        [JsonPropertyName("object_type")]
        // ReSharper disable once UnusedMember.Global
        public string ObjectType { get; set; } = string.Empty;

        [JsonPropertyName("object_id")]
        // ReSharper disable once UnusedMember.Global
        public long ObjectId { get; set; } = 0;

        [JsonPropertyName("action")]
        // ReSharper disable once UnusedMember.Global
        public string Action { get; set; } = string.Empty;

        [JsonPropertyName("date")]
        // ReSharper disable once UnusedMember.Global
        public DateTimeOffset Date { get; set; } = DateTime.Now;

        [JsonPropertyName("user")]
        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Global
        public User User { get; set; } = new User();

        [JsonPropertyName("change")]
        // ReSharper disable once UnusedMember.Global
        public Change Change { get; set; } = new Change();

        public TranslationApproval()
        {

        }
    }
}