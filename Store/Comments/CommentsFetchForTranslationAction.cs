namespace OriinDictionary7.Store.Comments;

public record CommentsFetchForTranslationAction
{
    public long TranslationId { get; }
    public string Token { get; } = string.Empty;
    public string FetchedTranslationMessage { get; }


    public CommentsFetchForTranslationAction(long translationId, string token, string fetchedTranslationMessage)
    {
        TranslationId = translationId;
        Token = token;
        FetchedTranslationMessage = fetchedTranslationMessage;
    }
}