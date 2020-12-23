namespace OriinDic.Store.Search
{
    
    public record SearchTranslationsAction
    {

        public string SearchText { get; } = string.Empty;

        public long BaseTermLangId { get; }
        public long TranslationLangId { get; }
        public long SearchPageNr { get; }
        public long ItemsPerPage { get; }

        public bool Current { get; }
        public string NoResults { get; } = string.Empty;
        public string SearchTranslationMessage { get; }

        public SearchTranslationsAction(string searchText, long baseTermLangId, long translationLangId, long searchPageNr,
            long itemsPerPage, bool current, string noResults, string searchTranslationMessage)
        {
            SearchText = searchText;
            BaseTermLangId = baseTermLangId;
            TranslationLangId = translationLangId;
            SearchPageNr = searchPageNr;
            ItemsPerPage = itemsPerPage;
            Current = current;
            NoResults = noResults;
            SearchTranslationMessage = searchTranslationMessage;
        }

        
    }
}