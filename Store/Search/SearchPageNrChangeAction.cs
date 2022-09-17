namespace OriinDic.Store.Search
{
    public record SearchPageNrChangeAction
    {
        public string PageActionName { get; } = string.Empty;
        public string SearchText { get; } = string.Empty;
        public long BaseTermLangId { get; }
        public long TranslationLangId { get; }
        public long ItemsPerPage { get; }
        public long SearchPageNr { get; }
        public bool Current { get; }
        public string NoResults { get; } = string.Empty;
        public string SearchTranslationMessage { get; }

        public SearchPageNrChangeAction(string pageActionName, string searchText, long baseTermLangId, long translationLangId,
            long itemsPerPage, long searchPageNr, bool current, string noResults, string searchTranslationMessage)
        {
            PageActionName = pageActionName;
            SearchText = searchText;
            BaseTermLangId = baseTermLangId;
            TranslationLangId = translationLangId;
            ItemsPerPage = itemsPerPage;
            SearchPageNr = searchPageNr;
            Current = current;
            NoResults = noResults;
            SearchTranslationMessage = searchTranslationMessage;
        }
    }
}