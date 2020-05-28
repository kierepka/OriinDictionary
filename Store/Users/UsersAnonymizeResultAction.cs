using OriinDic.Models;

namespace OriinDic.Store.Users
{
    public class UsersAnonymizeResultAction
    {
        public User User { get; }
        public string StatusCode { get; }

        public UsersAnonymizeResultAction(User user, string statusCode)
        {
            User = user;
            StatusCode = statusCode;
        }
    }
}
