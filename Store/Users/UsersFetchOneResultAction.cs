using OriinDic.Models;

using System.Net;

namespace OriinDic.Store.Users
{
    public record UsersFetchOneResultAction
    {
        public User User { get; } = new();
        public HttpStatusCode ResultCode { get; } = HttpStatusCode.BadRequest;
        public UsersFetchOneResultAction(User user, HttpStatusCode resultCode)
        {
            User = user;
            ResultCode = resultCode;
        }
    }
}
