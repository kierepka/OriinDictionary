namespace OriinDic.Store.Comments
{
    public class CommentsDeleteAction
    {
        public string Token { get; }
        public long CommentId { get; }

        public CommentsDeleteAction(long commentId, string token)
        {
            Token = token;
            CommentId = commentId;
        }
    }
}