using System.Net;

namespace OriinDictionary7.Store.Users;

public record UsersCreationConfirmResultAction
{
    public HttpStatusCode StatusCode { get; } = HttpStatusCode.OK;

    public UsersCreationConfirmResultAction(HttpStatusCode statusCode)
    {
        StatusCode = statusCode;
    }
}
