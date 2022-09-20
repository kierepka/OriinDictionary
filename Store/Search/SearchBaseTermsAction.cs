using OriinDictionary7.Models;

namespace OriinDictionary7.Store.Search;

public record SearchBaseTermsAction
{
    public string SearchText { get; } = string.Empty;
    public long BaseTermLangId { get; }
    public long TranslationLangId { get; }
    public long SearchPageNr { get; }
    public long ItemsPerPage { get; }
    public bool Current { get; }
    public string NoResults { get; } = string.Empty;
    public EnumHasTranslations HasTranslations { get; }
    public string SearchBaseTermMessage { get; }

    public SearchBaseTermsAction(string searchText, long baseTermLangId, long translationLangId, long searchPageNr,
        long itemsPerPage, bool current, string noResults, EnumHasTranslations hasTranslations, string searchBaseTermMessage)
    {
        SearchText = searchText;
        BaseTermLangId = baseTermLangId;
        TranslationLangId = translationLangId;
        SearchPageNr = searchPageNr;
        ItemsPerPage = itemsPerPage;
        Current = current;
        NoResults = noResults;
        HasTranslations = hasTranslations;
        SearchBaseTermMessage = searchBaseTermMessage;
    }

}