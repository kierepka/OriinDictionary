using OriinDic.Models;

namespace OriinDic.Store.Users
{
    public class UsersUpdateAction
    {

        public long UserId { get; init; } = 0;
        public UserUpdate User { get; init; } = new UserUpdate();
        public string Token { get; init; } = string.Empty;

        public UsersUpdateAction(long userId, UserUpdate user, string token)
        {
            UserId = userId;
            User = user;
            Token = token;
        }

        public UsersUpdateAction(UserUpdate user, string token)
        {
            User = user;
            Token = token;
        }
    }
}