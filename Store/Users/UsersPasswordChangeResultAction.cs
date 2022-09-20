using System.Net;

namespace OriinDictionary7.Store.Users;

public record UsersPasswordChangeResultAction
{
    public HttpStatusCode StatusCode { get; } = HttpStatusCode.OK;

    public UsersPasswordChangeResultAction(HttpStatusCode statusCode)
    {

        StatusCode = statusCode;

    }
}
