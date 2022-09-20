namespace OriinDictionary7.Store.Translations;

public class TranslationsFetch4EditAction
{
    public long TranslationId { get; init; } = 0;
    public string Token { get; init; } = string.Empty;
    public string NoData { get; init; } = string.Empty;

    public string DataLoadedMessage { get; init; } = string.Empty;

    public TranslationsFetch4EditAction(long translationId, string token, string noData, string dataLoadedMessage)
    {
        TranslationId = translationId;
        Token = token;
        NoData = noData;
        DataLoadedMessage = dataLoadedMessage;
    }
}