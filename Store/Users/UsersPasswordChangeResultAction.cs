using System.Net;
using OriinDic.Models;

namespace OriinDic.Store.Users
{
    public record UsersPasswordChangeResultAction
    {
        public User User { get; } = new();
        public HttpStatusCode StatusCode { get; } = HttpStatusCode.OK;
        
        public UsersPasswordChangeResultAction(User user, HttpStatusCode statusCode)
        {
            User = user;
            StatusCode = statusCode;
        
        }
    }
}
