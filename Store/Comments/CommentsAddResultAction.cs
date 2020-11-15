using OriinDic.Models;

namespace OriinDic.Store.Comments
{
    public class CommentsAddResultAction
    {
        public Comment Comment { get; init; } = new Comment();
        public string StatusCode { get; init; } = string.Empty;
        public RootObject<Comment> RootObject { get; init; } = new RootObject<Comment>();

        public CommentsAddResultAction(Comment comment, string statusCode, RootObject<Comment> rootObject)
        {
            Comment = comment;
            StatusCode = statusCode;
            RootObject = rootObject;
        }
    }
}
