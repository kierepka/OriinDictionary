using System;
using System.Text.Json.Serialization;

namespace OriinDic.Models
{
    public class Comment : CommentAdd
    {
        [JsonPropertyName("user")]
        public User User { get; set; }
        [JsonPropertyName("id")]        
        public long Id { get; set; }
        [JsonPropertyName("date")]
        public DateTimeOffset Date { get; set; }

        public Comment()
        {
                
        }
    }
}
