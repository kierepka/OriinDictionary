namespace OriinDic.Store.Search
{
    public class SearchPageNrChangeAction
    {
        public string PageActionName { get; private set;}
        public string SearchText { get; private set; }
        public long BaseTermLangId { get; private set; }
        public long TranslationLangId { get; private set; }        
        public long ItemsPerPage { get; private set; }
        public long SearchPageNr { get; private set; }
        public bool Current { get; private set; }
        public string NoResults { get; private set; }

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