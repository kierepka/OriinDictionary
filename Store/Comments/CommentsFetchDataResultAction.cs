using OriinDictionary7.Models;

using System.Net;

namespace OriinDictionary7.Store.Comments;

public class CommentsFetchDataResultAction
{
    public RootObject<Comment> RootObject { get; } = new();
    public HttpStatusCode HttpStatusCode { get; }

    public CommentsFetchDataResultAction(RootObject<Comment> rootObject, HttpStatusCode httpStatusCode)
    {
        RootObject = rootObject;
        HttpStatusCode = httpStatusCode;
    }
}
