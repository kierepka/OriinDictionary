namespace OriinDic.Models
{
    public class LoginResult
    {
        public bool Successful { get; set; } = false;

        public string Error { get; set; } = string.Empty;

        public string Token { get; set; } = string.Empty;

        public LoginResult()
        {
            
        }
    }
}