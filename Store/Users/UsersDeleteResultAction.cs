using OriinDictionary7.Models;

using System.Net;

namespace OriinDictionary7.Store.Users;

public record UsersDeleteResultAction
{
    public DeletedObjectResponse DeleteResponse { get; init; } = new();
    public HttpStatusCode ResultCode { get; } = HttpStatusCode.BadRequest;

    public UsersDeleteResultAction(DeletedObjectResponse deleteResponse, HttpStatusCode resultCode)
    {
        DeleteResponse = deleteResponse;
        ResultCode = resultCode;
    }
}
