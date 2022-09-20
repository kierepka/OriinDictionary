using OriinDictionary7.Models;

using System.Net;

namespace OriinDictionary7.Store.Comments;

public record CommentsDeleteResultAction
{
    public DeletedObjectResponse DeleteResponse { get; init; } = new();
    public RootObject<Comment> RootObject { get; init; } = new();
    public HttpStatusCode HttpStatusCode { get; }

    public CommentsDeleteResultAction(DeletedObjectResponse deleteResponse, RootObject<Comment> rootObject,
        HttpStatusCode httpStatusCode)
    {
        DeleteResponse = deleteResponse;
        RootObject = rootObject;
        HttpStatusCode = httpStatusCode;
    }
}
