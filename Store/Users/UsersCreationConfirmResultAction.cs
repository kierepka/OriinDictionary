using System.Net;
using OriinDic.Models;

namespace OriinDic.Store.Users
{
    public record UsersCreationConfirmResultAction
    {
        public HttpStatusCode StatusCode { get; } = HttpStatusCode.OK;
        
        public UsersCreationConfirmResultAction(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }
    }
}
