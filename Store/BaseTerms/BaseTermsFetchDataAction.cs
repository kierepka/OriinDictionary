namespace OriinDic.Store.BaseTerms
{
    public class BaseTermsFetchDataAction
    {
        public long BaseTermId { get; init; }
        public string Slug { get; init; }

        public string SearchText { get; init; }

        public long BaseTermLangId { get; init; }
        public long TranslationLangId { get; init; }
        public int SearchPageNr { get; init; }
        public long ItemsPerPage { get; init; }

        public bool Current { get; init; }

        public string Token { get; init; }

        public BaseTermsFetchDataAction(string slug, string token)
        {
            Slug = slug;
            Token = token;

            BaseTermId = long.MinValue;
            SearchText = string.Empty;
            BaseTermLangId = long.MinValue;
            TranslationLangId = long.MinValue;
            SearchPageNr = int.MinValue;
            Current = false;

        }

        public BaseTermsFetchDataAction(long baseTermId, string token)
        {
            BaseTermId = baseTermId;
            Token = token;

            Slug = string.Empty;
            SearchText = string.Empty;
            BaseTermLangId = long.MinValue;
            TranslationLangId = long.MinValue;
            SearchPageNr = int.MinValue;
            Current = false;
        }

        public BaseTermsFetchDataAction(string searchText, long baseTermLangId, long translationLangId, int searchPageNr, long itemsPerPage, bool current, string token)
        {
            SearchText = searchText;
            BaseTermLangId = baseTermLangId;
            TranslationLangId = translationLangId;
            SearchPageNr = searchPageNr;
            ItemsPerPage = itemsPerPage;
            Current = current;
            Token = token;
            Slug = string.Empty;
        }

        
    }
}