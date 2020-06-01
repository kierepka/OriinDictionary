namespace OriinDic.Store.Search
{
    public class SearchBaseTermsAction
    {
        public string SearchText { get; }
        public long BaseTermLangId { get; }
        public long TranslationLangId { get; }
        public long SearchPageNr { get; }
        public long ItemsPerPage { get; }
        public bool Current { get; }
        public string NoResults { get; }

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