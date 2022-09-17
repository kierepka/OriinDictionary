using OriinDictionary7.Models;

using System.Net;

namespace OriinDictionary7.Store.Users;

public record UsersAddResultAction
{
    public User User { get; } = new();

    public HttpStatusCode ResultCode { get; } = HttpStatusCode.BadRequest;

    public UsersAddResultAction(User user, HttpStatusCode resultCode)
    {
        User = user;
        ResultCode = resultCode;
    }
}
