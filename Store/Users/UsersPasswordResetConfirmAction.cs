using OriinDic.Models;

namespace OriinDic.Store.Users
{
    public record UsersPasswordResetConfirmAction
    {
        public string Token { get; } = string.Empty;
        public User User { get; } = new();
        public string UserPasswordResetConfirmMessage { get; } = string.Empty;
        
        public UsersPasswordResetConfirmAction(User user, string token, string userPasswordResetConfirmMessage)
        {
            Token = token;
            UserPasswordResetConfirmMessage = userPasswordResetConfirmMessage;
            User = user;
        }
    }
}