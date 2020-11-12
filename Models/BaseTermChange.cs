using System.Text.Json.Serialization;

namespace OriinDic.Models
{
    public class BaseTermChange
    {
        [JsonPropertyName("after")]
        //[JsonIgnore(Condition = JsonIgnoreCondition.WhenNull)]
        public BaseTerm After { get; set; } = new BaseTerm();

        [JsonPropertyName("before")]
        //[JsonIgnore(Condition = JsonIgnoreCondition.WhenNull)]
        public BaseTerm Before { get; set; } = new BaseTerm();

    }
}