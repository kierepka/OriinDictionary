using System.Text.Json.Serialization;

namespace OriinDic.Models
{
    public class DeletedObjectResponse
    {
        [JsonPropertyName("deleted")]
        public bool Deleted { get; set; }
        [JsonPropertyName("detail")]
        public string Detail { get; set; } = string.Empty;

        public DeletedObjectResponse()
        {
            
        }
    }
}
