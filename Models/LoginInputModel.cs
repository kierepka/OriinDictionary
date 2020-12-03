using System.ComponentModel.DataAnnotations;

namespace OriinDic.Models
{
    public record LoginInput
    {
        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Global
        [Required] public string Username { get; set; }= string.Empty;

        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Global
        [Required] public string Password { get; set; }= string.Empty;
    }
}