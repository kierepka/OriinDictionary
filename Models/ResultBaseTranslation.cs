using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OriinDic.Models
{
    public class ResultBaseTranslation
    {
        [JsonPropertyName("base_term")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public BaseTerm? BaseTerm { get; set; }
        
        [JsonPropertyName("translation")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Translation? Translation { get; set; }

        [JsonPropertyName("translations")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<Translation>? Translations { get; set; }

        public ResultBaseTranslation()
        {
            
        }
    }
}