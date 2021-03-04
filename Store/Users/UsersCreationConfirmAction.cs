using OriinDic.Models;

namespace OriinDic.Store.Users
{
    public record UsersCreationConfirmAction
    {
        public string Token { get; } = string.Empty;
        public UserPwdResetUpdate User { get; } = new();
        public string UserPasswordResetConfirmMessage { get; } = string.Empty;
        
        public UsersCreationConfirmAction(
            UserPwdResetUpdate user, string token, string userPasswordResetConfirmMessage)
        {
            Token = token;
            UserPasswordResetConfirmMessage = userPasswordResetConfirmMessage;
            User = user;
        }
    }
}