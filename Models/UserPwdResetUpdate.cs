using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OriinDic.Models
{
    public record UserPwdResetUpdate
    {

        [JsonPropertyName("new_password")]
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        [Required]
        [DataType( DataType.Password )]
        public string NewPassword { get; set; } = string.Empty;

        [JsonPropertyName("re_new_password")]
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        
        [Required]
        [DataType( DataType.Password )]
        [Compare( "NewPassword" )]
        public string ReNewPassword { get; set; } = string.Empty;
        
        [JsonPropertyName("token")]
        [Required]
        [DataType( DataType.Text )]
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public string Token { get; set; } = string.Empty;

        [JsonPropertyName("uid")]
        [Required]
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public string UserId { get; set; } = string.Empty;
        
        public UserPwdResetUpdate()
        {

        }
    }
}