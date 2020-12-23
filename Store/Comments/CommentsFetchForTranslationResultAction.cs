using System.Net;
using OriinDic.Models;

namespace OriinDic.Store.Comments
{
    public class CommentsFetchForTranslationResultAction
    {
        public RootObject<Comment> RootObject { get; } = new();
        public HttpStatusCode HttpStatusCode { get; }

        public CommentsFetchForTranslationResultAction(RootObject<Comment> rootObject, HttpStatusCode httpStatusCode)
        {
            RootObject = rootObject;
            HttpStatusCode = httpStatusCode;
        }
    }
}
