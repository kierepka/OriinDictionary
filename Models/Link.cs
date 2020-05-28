using System.Text.Json.Serialization;

namespace OriinDic.Models
{
    public class OriinLink
    {
        public OriinLink()
        {

        }

        [JsonPropertyName("approved")]
        public bool Approved { get; set; }

        [JsonPropertyName("base_term_id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenNull)]
        public long BaseTermId { get; set; }

        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("link")]
        public string Link { get; set; }
        [JsonPropertyName("translation_id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenNull)]
        public long TranslationId { get; set; }
    }
}