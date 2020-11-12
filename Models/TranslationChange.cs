using System.Text.Json.Serialization;

namespace OriinDic.Models
{
    public class TranslationChange
    {
        [JsonPropertyName("after")]
        public Translation After { get; set; } = new Translation();

        [JsonPropertyName("before")]
        public Translation Before { get; set; } = new Translation();
    }
}