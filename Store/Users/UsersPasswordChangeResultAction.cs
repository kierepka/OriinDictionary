using System.Net;

namespace OriinDic.Store.Users
{
    public record UsersPasswordChangeResultAction
    {
        public HttpStatusCode StatusCode { get; } = HttpStatusCode.OK;

        public UsersPasswordChangeResultAction(HttpStatusCode statusCode)
        {

            StatusCode = statusCode;

        }
    }
}
