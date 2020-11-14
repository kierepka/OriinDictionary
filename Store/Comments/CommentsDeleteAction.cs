namespace OriinDic.Store.Comments
{
    public class CommentsDeleteAction
    {
        public string Token { get; init; } = string.Empty;
        public long CommentId { get; init; } = 0;

        public CommentsDeleteAction(long commentId, string token)
        {
            Token = token;
            CommentId = commentId;
        }
    }
}