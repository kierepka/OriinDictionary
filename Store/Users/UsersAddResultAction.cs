using OriinDic.Models;

namespace OriinDic.Store.Users
{
    public class UsersAddResultAction
    {
        public User User { get; init; } = new User();
        public string StatusCode { get; init; } = string.Empty;

        public UsersAddResultAction(User user, string statusCode)
        {
            User = user;
            StatusCode = statusCode;
        }
    }
}
