using OriinDic.Models;

namespace OriinDic.Store.Users
{
    public class UsersUpdateResultAction
    {
        public User User { get; }

        public UsersUpdateResultAction(User user)
        {
            User = user;
        }
    }
}
