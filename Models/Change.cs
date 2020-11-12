using System.Text.Json.Serialization;

namespace OriinDic.Models
{


    public class Change 
    {
        [JsonPropertyName("after")]
        public BaseTerm After { get; set; } = new BaseTerm();

        [JsonPropertyName("before")]
        public BaseTerm Before { get; set; } = new BaseTerm();


        public Change()
        {

        }
    }
}
