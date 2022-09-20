namespace OriinDictionary7.Store.Translations;

public class TranslationsFetchDataAction
{

    public string SearchText { get; init; } = string.Empty;
    public long BaseTermLangId { get; init; } = 0;
    public long LangId { get; init; } = 0;
    public int SearchPageNr { get; init; } = 0;
    public long ItemsPerPage { get; init; } = 0;
    public bool Current { get; init; } = false;

    public string DataLoadedMessage { get; init; } = string.Empty;

    public TranslationsFetchDataAction(string searchText,
            long baseTermLangId,
            long langId,
            int searchPageNr,
            long itemsPerPage,
            bool current,
            string dataLoadedMessage)
    {
        SearchText = searchText;
        BaseTermLangId = baseTermLangId;
        LangId = langId;
        SearchPageNr = searchPageNr;
        ItemsPerPage = itemsPerPage;
        Current = current;
        DataLoadedMessage = dataLoadedMessage;
    }


}