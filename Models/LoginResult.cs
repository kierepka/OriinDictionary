namespace OriinDic.Models
{
    public class LoginResult
    {
        public bool Successful { get; set; }

        public string Error { get; set; } = string.Empty;

        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public string Token { get; set; } = string.Empty;
    }
}