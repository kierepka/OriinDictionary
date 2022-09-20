using OriinDictionary7.Models;

using System.Net;

namespace OriinDictionary7.Store.Users;

public record UsersAnonymizeResultAction
{
    public User User { get; } = new();
    public HttpStatusCode ResultCode { get; } = HttpStatusCode.OK;

    public UsersAnonymizeResultAction(User user, HttpStatusCode resultCode)
    {
        User = user;
        ResultCode = resultCode;

    }
}
