using System.Text.Json.Serialization;

namespace OriinDic.Models
{
    public class OriinLink
    {
        public OriinLink()
        {

        }

        [JsonPropertyName("approved")]
        public bool Approved { get; set; } = false;

        [JsonPropertyName("base_term_id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? BaseTermId { get; set; }

        [JsonPropertyName("id")]
        public long Id { get; set; } = long.MinValue;

        [JsonPropertyName("link")]
        public string Link { get; set; } = string.Empty;

        [JsonPropertyName("translation_id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? TranslationId { get; set; }
    }
}