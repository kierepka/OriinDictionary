using OriinDic.Models;

namespace OriinDic.Store.Users
{
    public class UsersAddAction
    {
        public string Token { get; }
        public UserAdd User { get; }

        public UsersAddAction(UserAdd user, string token)
        {
            Token = token;
            User = user;
        }
    }
}