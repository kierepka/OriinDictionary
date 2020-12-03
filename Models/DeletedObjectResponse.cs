using System.Text.Json.Serialization;

namespace OriinDic.Models
{
    public record DeletedObjectResponse
    {
        [JsonPropertyName("deleted")]
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public bool Deleted { get; set; }
        [JsonPropertyName("detail")]
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public string Detail { get; set; } = string.Empty;

        public DeletedObjectResponse()
        {

        }
    }
}
