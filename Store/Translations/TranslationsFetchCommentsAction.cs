namespace OriinDictionary7.Store.Translations;

public record TranslationsFetchCommentsAction
{
    public long TranslationId { get; }
    public string Token { get; } = string.Empty;
    public string CommentsFetchedMessage { get; }


    public TranslationsFetchCommentsAction(long translationId, string token,
        string commentsFetchedMessage)
    {
        TranslationId = translationId;
        Token = token;
        CommentsFetchedMessage = commentsFetchedMessage;
    }
}