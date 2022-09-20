using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OriinDictionary7.Models;

public record UserPwdReset
{


    [JsonPropertyName("email")]
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    public UserPwdReset()
    {

    }
}