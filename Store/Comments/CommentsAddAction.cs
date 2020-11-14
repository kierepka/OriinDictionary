using OriinDic.Models;

namespace OriinDic.Store.Comments
{
    public class CommentsAddAction
    {
        public string Token { get; init; } = string.Empty;
        public Comment Comment { get; init; } = new Comment();

        public CommentsAddAction(Comment comment, string token)
        {
            Token = token;
            Comment = comment;
        }
    }
}