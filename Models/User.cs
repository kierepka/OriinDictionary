using System.Text.Json.Serialization;

namespace OriinDic.Models
{

    public class User : UserUpdate
    {
        [JsonPropertyName("id")]
        public long Id { get; set; } = long.MinValue;

        [JsonPropertyName("is_superuser")]
        public bool IsSuperuser { get; set; } = false;

        public User()
        {
            
        }
    }
}