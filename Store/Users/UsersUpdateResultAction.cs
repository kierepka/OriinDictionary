using System.Net;
using OriinDic.Models;

namespace OriinDic.Store.Users
{
    public record UsersUpdateResultAction
    {
        public User User { get; } = new();
        public HttpStatusCode ResultCode { get; } = HttpStatusCode.BadRequest;
        
        public UsersUpdateResultAction(User user, HttpStatusCode resultCode)
        {
            User = user;
            ResultCode = resultCode;
        }
    }
}
