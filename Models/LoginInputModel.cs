using System.ComponentModel.DataAnnotations;

namespace OriinDic.Models
{
    public class LoginInput
    {
        [Required] public string Username { get; set; }= string.Empty;

        [Required] public string Password { get; set; }= string.Empty;
    }
}