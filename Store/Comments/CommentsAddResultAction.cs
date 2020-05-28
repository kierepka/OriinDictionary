using OriinDic.Models;

namespace OriinDic.Store.Comments
{
    public class CommentsAddResultAction
    {
        public Comment Comment { get; }
        public string StatusCode { get; }

        public CommentsAddResultAction(Comment comment, string statusCode)
        {
            Comment = comment;
            StatusCode = statusCode;
        }
    }
}
