using System.Text.Json.Serialization;

namespace OriinDic.Models
{
    public class TranslationChange
    {
        [JsonPropertyName("after")]
        public Translation After { get; set; }

        [JsonPropertyName("before")]
        public object Before { get; set; }
    }
}