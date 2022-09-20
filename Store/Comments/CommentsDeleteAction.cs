namespace OriinDictionary7.Store.Comments;

public record CommentsDeleteAction
{
    public string Token { get; } = string.Empty;
    public long CommentId { get; }
    public string CommentDeletedMessage { get; }

    public CommentsDeleteAction(long commentId, string token, string commentDeletedMessage)
    {
        Token = token;
        CommentDeletedMessage = commentDeletedMessage;
        CommentId = commentId;
    }
}