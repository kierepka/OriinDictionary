using System.Net;
using OriinDic.Models;

namespace OriinDic.Store.Users
{
    public record UsersPasswordResetResultAction
    {
        public User User { get; } = new();
        public HttpStatusCode StatusCode { get; } = HttpStatusCode.OK;
        
        public UsersPasswordResetResultAction(User user, HttpStatusCode statusCode)
        {
            User = user;
            StatusCode = statusCode;
        
        }
    }
}
