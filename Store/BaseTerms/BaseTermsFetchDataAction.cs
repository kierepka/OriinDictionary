namespace OriinDic.Store.BaseTerms
{
    public class BaseTermsFetchDataAction
    {
        public long BaseTermId { get; }
        public string Slug { get; }

        public string SearchText { get; }

        public long BaseTermLangId { get; }
        public long TranslationLangId { get; }
        public int SearchPageNr { get; }
        public long ItemsPerPage { get; }

        public bool Current { get; }

        public BaseTermsFetchDataAction(string slug)
        {
            Slug = slug;
        }

        public BaseTermsFetchDataAction(long baseTermId)
        {
            BaseTermId = baseTermId;
        }

        public BaseTermsFetchDataAction(string searchText, long baseTermLangId, long translationLangId, int searchPageNr, long itemsPerPage, bool current)
        {
            SearchText = searchText;
            BaseTermLangId = baseTermLangId;
            TranslationLangId = translationLangId;
            SearchPageNr = searchPageNr;
            ItemsPerPage = itemsPerPage;
            Current = current;
        }

        
    }
}