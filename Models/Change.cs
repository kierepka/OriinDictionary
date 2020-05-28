using System.Text.Json.Serialization;

namespace OriinDic.Models
{


    public class Change 
    {
        [JsonPropertyName("after")]
        public BaseTerm After { get; set; }
        [JsonPropertyName("before")]
        public BaseTerm Before { get; set; }


        public Change()
        {

        }
    }
}
