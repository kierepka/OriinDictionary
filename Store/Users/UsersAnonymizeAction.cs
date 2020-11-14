using OriinDic.Models;

namespace OriinDic.Store.Users
{
    public class UsersAnonymizeAction
    {
        public string Token { get; init; } = string.Empty;
        public User User { get; init; } = new User();

        public UsersAnonymizeAction(User user, string token)
        {
            Token = token;
            User = user;
        }
    }
}