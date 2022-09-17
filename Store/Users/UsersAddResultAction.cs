using OriinDic.Models;

using System.Net;

namespace OriinDic.Store.Users
{
    public record UsersAddResultAction
    {
        public User User { get; } = new();

        public HttpStatusCode ResultCode { get; } = HttpStatusCode.BadRequest;

        public UsersAddResultAction(User user, HttpStatusCode resultCode)
        {
            User = user;
            ResultCode = resultCode;
        }
    }
}
