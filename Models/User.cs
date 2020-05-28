using System.Text.Json.Serialization;

namespace OriinDic.Models
{

    public class User : UserUpdate
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("is_superuser")]
        public bool IsSuperuser { get; set; }

        public User()
        {
            
        }
    }
}