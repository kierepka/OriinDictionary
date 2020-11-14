using OriinDic.Models;

namespace OriinDic.Store.Users
{
    public class UsersAnonymizeResultAction
    {
        public User User { get; init; } = new User();
        public string StatusCode { get; init; } = string.Empty;

        public UsersAnonymizeResultAction(User user, string statusCode)
        {
            User = user;
            StatusCode = statusCode;
        }
    }
}
