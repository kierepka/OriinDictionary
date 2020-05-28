using OriinDic.Models;

namespace OriinDic.Store.Users
{
    public class UsersAnonymizeAction
    {
        public string Token { get; }
        public User User { get; }

        public UsersAnonymizeAction(User user, string token)
        {
            Token = token;
            User = user;
        }
    }
}