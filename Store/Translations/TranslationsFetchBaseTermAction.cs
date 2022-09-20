namespace OriinDictionary7.Store.Translations;

public record TranslationsFetchBaseTermAction
{
    public long BaseTermId { get; }
    public string FetchBaseSuccessMessage { get; } = string.Empty;

    public TranslationsFetchBaseTermAction(long baseTermId, string fetchBaseSuccessMessage)
    {
        BaseTermId = baseTermId;
        FetchBaseSuccessMessage = fetchBaseSuccessMessage;
    }
}