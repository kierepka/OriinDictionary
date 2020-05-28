using OriinDic.Models;

namespace OriinDic.Store.Users
{
    public class UsersUpdateAction
    {

        public long UserId { get; }
        public UserUpdate User { get; }
        public string Token { get; }

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