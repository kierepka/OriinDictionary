using OriinDictionary7.Models;

namespace OriinDictionary7.Store.Translations;

public record TranslationsCommentAddAction
{
    public string Token { get; } = string.Empty;
    public Comment Comment { get; } = new();
    public string CommentAddedMessage { get; } = string.Empty;
    public long TranslationId { get; }

    public TranslationsCommentAddAction(Comment comment, string token,
        long translationId, string commentAddedMessage)
    {
        Token = token;
        Comment = comment;
        TranslationId = translationId;
        CommentAddedMessage = commentAddedMessage;
    }
}

