using OriinDic.Models;

namespace OriinDic.Store.BaseTerms
{
    public record BaseTermsFetchDataAction
    {
        public long BaseTermId { get; }
        public string Slug { get; } = string.Empty;

        public string SearchText { get; } = string.Empty;

        public long BaseTermLangId { get; }
        public long TranslationLangId { get; }
        public int SearchPageNr { get; }
        public long ItemsPerPage { get; }

        public bool Current { get; }

        public string Token { get; } = string.Empty;
        public EnumHasTranslations HasTranslations { get; }
        public string BaseTermFetchedMessage { get; }

        public BaseTermsFetchDataAction(
            string searchText, long baseTermLangId, long translationLangId,
            int searchPageNr, long itemsPerPage, bool current,
            EnumHasTranslations hasTranslations, string token, string slug,
            long baseTermId, string baseTermFetchedMessage)
        {
            SearchText = searchText;
            BaseTermLangId = baseTermLangId;
            TranslationLangId = translationLangId;
            SearchPageNr = searchPageNr;
            ItemsPerPage = itemsPerPage;
            Current = current;
            Token = token;
            Slug = slug;
            BaseTermId = baseTermId;
            BaseTermFetchedMessage = baseTermFetchedMessage;
            HasTranslations = hasTranslations;
        }


    }
}