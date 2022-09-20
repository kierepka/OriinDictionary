namespace OriinDictionary7.Store.Links;

public record LinksFetchForBaseTermAction
{
    public long BaseTermId { get; }
    public string Token { get; } = string.Empty;
    public string LinkFetchedMessage { get; }


    public LinksFetchForBaseTermAction(long baseTermId, string token, string linkFetchedMessage)
    {
        BaseTermId = baseTermId;
        Token = token;
        LinkFetchedMessage = linkFetchedMessage;
    }
}