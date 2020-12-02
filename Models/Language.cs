using System.Text.Json.Serialization;

namespace OriinDic.Models
{
    public class Language
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
        [JsonPropertyName("code")]
        public string Code { get; set; } = string.Empty;
        [JsonPropertyName("special_characters")]
        public string SpecialCharacters { get; set; } = string.Empty;
    }
}