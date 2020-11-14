using OriinDic.Models;

namespace OriinDic.Store.Comments
{
    public class CommentsAddResultAction
    {
        public Comment Comment { get; init; } = new Comment();
        public string StatusCode { get; init; } = string.Empty;

        public CommentsAddResultAction(Comment comment, string statusCode)
        {
            Comment = comment;
            StatusCode = statusCode;
        }
    }
}
