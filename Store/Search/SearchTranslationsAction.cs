namespace OriinDic.Store.Search
{
    
    public class SearchTranslationsAction
    {
        
        public string SearchText { get; private set; }

        public long BaseTermLangId { get; private set; }
        public long TranslationLangId { get; private set; }
        public long SearchPageNr { get; private set; }
        public long ItemsPerPage { get; private set; }

        public bool Current { get; private set; }
        public string NoResults { get; private set; }

        public SearchTranslationsAction(string searchText, long baseTermLangId, long translationLangId, long searchPageNr,
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