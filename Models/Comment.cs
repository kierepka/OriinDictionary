using System;
using System.Text.Json.Serialization;

namespace OriinDic.Models
{
    public record Comment : CommentAdd
    {
        [JsonPropertyName("user")]
        public User User { get; set; } = new();

        [JsonPropertyName("id")]
        public long Id { get; set; } = 0;

        [JsonPropertyName("date")]
        public DateTimeOffset Date { get; set; } = DateTime.Now;

        public Comment()
        {

        }
    }
}
