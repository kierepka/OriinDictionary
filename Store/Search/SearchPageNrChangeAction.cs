namespace OriinDic.Store.Search
{
    public class SearchPageNrChangeAction
    {
        public string PageActionName { get; init; } = string.Empty;
        public string SearchText { get; init; } = string.Empty;
        public long BaseTermLangId { get; init; } = 0;
        public long TranslationLangId { get; init; } = 0;
        public long ItemsPerPage { get; init; } = 0;
        public long SearchPageNr { get; init; } = 0;
        public bool Current { get; init; } = false;
        public string NoResults { get; init; } = string.Empty;

        public SearchPageNrChangeAction(string pageActionName, string searchText, long baseTermLangId, long translationLangId, 
            long itemsPerPage, long searchPageNr, bool current, string noResults)
        {
            PageActionName = pageActionName;
            SearchText = searchText;
            BaseTermLangId = baseTermLangId;
            TranslationLangId = translationLangId;            
            ItemsPerPage = itemsPerPage;
            SearchPageNr = searchPageNr;
            Current = current;
            NoResults = noResults;            
        }
    }
}