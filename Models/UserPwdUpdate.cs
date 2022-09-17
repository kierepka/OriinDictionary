using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OriinDictionary7.Models;

public record UserPwdUpdate
{

    [JsonPropertyName("new_password")]
    // ReSharper disable once UnusedAutoPropertyAccessor.Global
    [Required]
    [DataType(DataType.Password)]
    public string NewPassword { get; set; } = string.Empty;

    [JsonPropertyName("re_new_password")]
    // ReSharper disable once UnusedAutoPropertyAccessor.Global

    [Required]
    [DataType(DataType.Password)]
    [Compare("NewPassword")]
    public string ReNewPassword { get; set; } = string.Empty;

    [JsonPropertyName("current_password")]
    [Required]
    [DataType(DataType.Password)]
    // ReSharper disable once UnusedAutoPropertyAccessor.Global
    public string CurrentPassword { get; set; } = string.Empty;

    public UserPwdUpdate()
    {

    }
}