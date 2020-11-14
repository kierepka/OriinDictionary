using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OriinDic.Models
{
    public class RootObject<T>
    {
        [JsonPropertyName("pages")]
        public long Pages { get; set; }
        [JsonPropertyName("count")]
        public long Count { get; set; }
        [JsonPropertyName("current_page")]
        public long CurrentPage { get; set; }
        [JsonPropertyName("results")]
        public List<T> Results { get; set; }
        public RootObject()
        {
            Results = new List<T>();            
        }
    }

}