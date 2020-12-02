using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OriinDic.Models
{
    public class UserUpdate : UserAdd
    {
        [JsonPropertyName("gender")]
        public string Gender { get; set; } = string.Empty;
        [JsonPropertyName("language_id")]
        public long? LanguageId { get; set; }
        [JsonPropertyName("assistant")]
        public bool Assistant { get; set; }
        [JsonPropertyName("translating_languages")]
        ////[JsonIgnore(Condition = JsonIgnoreCondition.WhenNull)]
        public List<int> TranslatingLanguages { get; set; } = new List<int>();
        [JsonPropertyName("coordinating_languages")]
        ////[JsonIgnore(Condition = JsonIgnoreCondition.WhenNull)]
        public List<int> CoordinatingLanguages { get; set; } = new List<int>();
    }
}