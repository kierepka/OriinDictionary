namespace OriinDictionary7.Store.BaseTerms;

public record BaseTermsFetchOneSlugAction
{
    public string Slug { get; } = string.Empty;
    public string Token { get; } = string.Empty;
    public string BaseTermFetchedMessage { get; }

    public BaseTermsFetchOneSlugAction(string slug, string token, string baseTermFetchedMessage)
    {
        Slug = slug;
        Token = token;
        BaseTermFetchedMessage = baseTermFetchedMessage;
    }
}