using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OriinDic.Models
{
    public class ResultBaseTranslation
    {
        [JsonPropertyName("base_term")]
        //[JsonIgnore(Condition = JsonIgnoreCondition.WhenNull)]
        public BaseTerm? BaseTerm { get; set; }
        [JsonPropertyName("translation")]
        //[JsonIgnore(Condition = JsonIgnoreCondition.WhenNull)]
        public Translation? Translation { get; set; }
        [JsonPropertyName("translations")]
        //[JsonIgnore(Condition = JsonIgnoreCondition.WhenNull)]
        public List<Translation>? Translations { get; set; }
        public ResultBaseTranslation()
        {
            
        }
    }
}