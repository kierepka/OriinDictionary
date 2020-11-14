using OriinDic.Models;

namespace OriinDic.Store.Users
{
    public class UsersUpdateResultAction
    {
        public User User { get; init; } = new User();

        public UsersUpdateResultAction(User user)
        {
            User = user;
        }
    }
}
