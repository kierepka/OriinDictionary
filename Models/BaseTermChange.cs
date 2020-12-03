using System.Text.Json.Serialization;

namespace OriinDic.Models
{
    public record BaseTermChange
    {
        [JsonPropertyName("after")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public BaseTerm After { get; set; } = new BaseTerm();

        [JsonPropertyName("before")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public BaseTerm Before { get; set; } = new BaseTerm();

        public BaseTermChange()
        {

        }
    }
}