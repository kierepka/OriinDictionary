using OriinDic.Models;

using System.Collections.Generic;

namespace OriinDic.Store.BaseTerms
{
    public class BaseTermsState
    {
        public EActionState LastActionState { get; init; } = EActionState.Initializing;
        public ResultBaseTranslation ResultBaseTranslation { get; init; } = new ResultBaseTranslation();
        public BaseTerm BaseTerm { get; init; } = new BaseTerm();
        public RootObject<ResultBaseTranslation> RootObject { get; init; } = new RootObject<ResultBaseTranslation>();
        public List<OriinLink> Links { get; init; } = new List<OriinLink>();

        public string BaseTermSlug { get; init; } = string.Empty;
        public long BaseTermId { get; init; } = 0;
        public string Token { get; init; } = string.Empty;
        public string SearchText { get; init; } = string.Empty;
        public long BaseTermLangId { get; init; } = 0;
        public long TranslationLangId { get; init; } = 0;
        public int SearchPageNr { get; init; } = 0;
        public long ItemsPerPage { get; init; } = 0;
        public bool Current { get; init; } = false;
        public bool IsLoading { get; init; } = false;

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