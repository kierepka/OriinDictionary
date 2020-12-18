using OriinDic.Models;

namespace OriinDic.Store.BaseTerms
{
    public class BaseTermsFetchDataAction
    {
        public long BaseTermId { get; init; } = 0;
        public string Slug { get; init; } = string.Empty;

        public string SearchText { get; init; } = string.Empty;

        public long BaseTermLangId { get; init; } = 0;
        public long TranslationLangId { get; init; } = 0;
        public int SearchPageNr { get; init; } = 0;
        public long ItemsPerPage { get; init; } = 0;

        public bool Current { get; init; } = false;

        public string Token { get; init; } = string.Empty;
        public EnumHasTranslations HasTranslations { get; init; }

        public BaseTermsFetchDataAction(string slug, string token)
        {
            Slug = slug;
            Token = token;
        }

        public BaseTermsFetchDataAction(long baseTermId, string token)
        {
            BaseTermId = baseTermId;
            Token = token;
        }

        public BaseTermsFetchDataAction(
            string searchText, long baseTermLangId, long translationLangId, 
            int searchPageNr, long itemsPerPage, bool current,
            EnumHasTranslations hasTranslations, string token)
        {
            SearchText = searchText;
            BaseTermLangId = baseTermLangId;
            TranslationLangId = translationLangId;
            SearchPageNr = searchPageNr;
            ItemsPerPage = itemsPerPage;
            Current = current;
            Token = token;
            HasTranslations = hasTranslations;
        }

        
    }
}