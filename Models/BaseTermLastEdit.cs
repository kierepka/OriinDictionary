using System;
using System.Text.Json.Serialization;

namespace OriinDic.Models
{
    public class BaseTermLastEdit
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("object_type")]
        //[JsonIgnore(Condition = JsonIgnoreCondition.WhenNull)]
        public string ObjectType { get; set; }

        [JsonPropertyName("object_id")]
        public long ObjectId { get; set; }

        [JsonPropertyName("action")]
        //[JsonIgnore(Condition = JsonIgnoreCondition.WhenNull)]
        public string Action { get; set; }

        [JsonPropertyName("date")]
        //[JsonIgnore(Condition = JsonIgnoreCondition.WhenNull)]
        public DateTimeOffset Date { get; set; }

        [JsonPropertyName("user")]
        //[JsonIgnore(Condition = JsonIgnoreCondition.WhenNull)]
        public User User { get; set; }

        [JsonPropertyName("change")]
        //[JsonIgnore(Condition = JsonIgnoreCondition.WhenNull)]
        public BaseTermChange Change { get; set; }
    }
}