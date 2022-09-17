using OriinDic.Models;

namespace OriinDic.Store.Users
{
    public record UsersPasswordChangeAction
    {
        public string Token { get; } = string.Empty;
        public UserPwdUpdate User { get; } = new();
        public string UserPasswordChangeMessage { get; } = string.Empty;

        public UsersPasswordChangeAction(UserPwdUpdate user, string token, string userPasswordChangeMessage)
        {
            Token = token;
            UserPasswordChangeMessage = userPasswordChangeMessage;
            User = user;
        }
    }
}