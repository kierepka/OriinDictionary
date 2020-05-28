using OriinDic.Models;

namespace OriinDic.Store.Users
{
    public class UsersFetchOneResultAction
    {
        public User User { get; }

        public UsersFetchOneResultAction(User user)
        {
            User = user;
        }
    }
}
