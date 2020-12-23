using OriinDic.Models;
using System.Collections.Generic;

namespace OriinDic.Store.BaseTerms
{
    public record BaseTermsState
    {
        public EActionState LastActionState { get; } = EActionState.Initializing;
        public ResultBaseTranslation ResultBaseTranslation { get; } = new();
        public BaseTerm BaseTerm { get; } = new();
        public RootObject<ResultBaseTranslation> RootObject { get; } = new();
        public List<OriinLink> Links { get; } = new();

        public string BaseTermSlug { get; } = string.Empty;
        public long BaseTermId { get; }
        public string Token { get; } = string.Empty;
        public string SearchText { get; } = string.Empty;
        public long BaseTermLangId { get; }
        public long TranslationLangId { get; }
        public int SearchPageNr { get; }
        public long ItemsPerPage { get; }
        public bool Current { get; }
        public bool IsLoading { get; }

        public BaseTermsState(
            bool isLoading,
            bool current,
            int searchPageNr,
            long baseTermLangId,
            long translationLangId,
            long baseTermId,
            long itemsPerPage,
            string searchText,
            string token,
            string baseTermSlug,
            BaseTerm baseTerm,
            RootObject<ResultBaseTranslation> rootObject,
            ResultBaseTranslation resultBaseTranslation,
            List<OriinLink> links,
            EActionState lastActionState)
        {
            LastActionState = lastActionState;
            IsLoading = isLoading;
            Current = current;
            SearchPageNr = searchPageNr;
            BaseTermLangId = baseTermLangId;
            TranslationLangId = translationLangId;
            BaseTermId = baseTermId;
            ItemsPerPage = itemsPerPage;
            SearchText = searchText;
            Token = token;
            BaseTerm = baseTerm;
            BaseTermSlug = baseTermSlug;
            RootObject = rootObject;
            ResultBaseTranslation = resultBaseTranslation;
            Links = links;
        }
    }
}