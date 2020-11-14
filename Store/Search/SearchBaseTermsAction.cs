namespace OriinDic.Store.Search
{
    public class SearchBaseTermsAction
    {
        public string SearchText { get; init; } = string.Empty;
        public long BaseTermLangId { get; init; } = 0;
        public long TranslationLangId { get; init; } = 0;
        public long SearchPageNr { get; init; } = 0;
        public long ItemsPerPage { get; init; } = 0;
        public bool Current { get; init; } = false;
        public string NoResults { get; init; } = string.Empty;

        public SearchBaseTermsAction(string searchText, long baseTermLangId, long translationLangId, long searchPageNr,
            long itemsPerPage, bool current, string noResults)
        {
            SearchText = searchText;
            BaseTermLangId = baseTermLangId;
            TranslationLangId = translationLangId;
            SearchPageNr = searchPageNr;
            ItemsPerPage = itemsPerPage;
            Current = current;
            NoResults = noResults;
        }

    }
}