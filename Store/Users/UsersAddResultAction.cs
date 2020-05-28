using OriinDic.Models;

namespace OriinDic.Store.Users
{
    public class UsersAddResultAction
    {
        public User User { get; }
        public string StatusCode { get; }

        public UsersAddResultAction(User user, string statusCode)
        {
            User = user;
            StatusCode = statusCode;
        }
    }
}
