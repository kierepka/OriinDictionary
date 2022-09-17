using OriinDic.Models;

using System.Net;

namespace OriinDic.Store.Comments
{
    public record CommentsAddResultAction
    {
        public Comment Comment { get; } = new();
        public string StatusCode { get; } = string.Empty;
        public RootObject<Comment> RootObject { get; } = new();
        public HttpStatusCode HttpStatusCode { get; }

        public CommentsAddResultAction(Comment comment, string statusCode, RootObject<Comment> rootObject,
            HttpStatusCode httpStatusCode)
        {
            Comment = comment;
            StatusCode = statusCode;
            RootObject = rootObject;
            HttpStatusCode = httpStatusCode;
        }
    }
}
