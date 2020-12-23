using OriinDic.Models;

namespace OriinDic.Store.Users
{
    public record UsersAnonymizeAction
    {
        public string Token { get; } = string.Empty;
        public User User { get; } = new();
        public string UserAnonymizedMessage { get; } = string.Empty;
        
        public UsersAnonymizeAction(User user, string token,  string userAnonymizedMessage)
        {
            Token = token;
            UserAnonymizedMessage = userAnonymizedMessage;
            User = user;
        }
    }
}