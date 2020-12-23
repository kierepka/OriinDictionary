using OriinDic.Models;

namespace OriinDic.Store.Users
{
    public record UsersUpdateAction
    {

        public long UserId { get; }
        public UserUpdate User { get; } = new();
        public string Token { get; } = string.Empty;
        public string UserUpdatedMessage { get; } = string.Empty;
        
        public UsersUpdateAction(long userId, UserUpdate user, string token, string userUpdatedMessage)
        {
            UserId = userId;
            User = user;
            Token = token;
            UserUpdatedMessage = userUpdatedMessage;
            
        }

    }
}