using System.Text.Json.Serialization;

namespace OriinDic.Models
{
    public class CommentAdd
    {
        [JsonPropertyName("translation_id")]
        public long TranslationId { get; set; } = long.MinValue;

        [JsonPropertyName("text")]
        public string Text { get; set; } = string.Empty;

        public CommentAdd()
        {
            
        }
    }
}