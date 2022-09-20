using OriinDictionary7.Models;

using System.Net;

namespace OriinDictionary7.Store.Users;

public record UsersPasswordResetConfirmResultAction
{
    public User User { get; } = new();
    public HttpStatusCode StatusCode { get; } = HttpStatusCode.OK;

    public UsersPasswordResetConfirmResultAction(User user, HttpStatusCode statusCode)
    {
        User = user;
        StatusCode = statusCode;

    }
}
