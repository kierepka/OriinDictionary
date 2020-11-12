using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OriinDic.Models
{
    public class RootObject<T>
    {
        [JsonPropertyName("pages")]
        public long Pages { get; set; } = long.MinValue;

        [JsonPropertyName("count")]
        public long Count { get; set; } = long.MinValue;

        [JsonPropertyName("current_page")]
        public long CurrentPage { get; set; } = long.MinValue;

        [JsonPropertyName("results")]
        public List<T> Results { get; set; } = new List<T>();
        public RootObject()
        {                     
        }
    }

}