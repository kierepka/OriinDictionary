using System.Text.Json.Serialization;

namespace OriinDic.Models
{
    public record OriinLink
    {
        [JsonPropertyName("approved")]
        // ReSharper disable once UnusedMember.Global
        public bool Approved { get; set; } = false;

        [JsonPropertyName("base_term_id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? BaseTermId { get; set; } = 0;

        [JsonPropertyName("id")]
        public long Id { get; set; } = 0;

        [JsonPropertyName("link")]
        public string Link { get; set; } = string.Empty;

        [JsonPropertyName("translation_id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? TranslationId { get; set; } = 0;

        public OriinLink()
        {

        }
    }
}