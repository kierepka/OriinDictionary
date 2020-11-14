using OriinDic.Models;

namespace OriinDic.Store.Users
{
    public class UsersAddAction
    {
        public string Token { get; init; } = string.Empty;
        public UserAdd User { get; init; } = new UserAdd();

        public UsersAddAction(UserAdd user, string token)
        {
            Token = token;
            User = user;
        }
    }
}