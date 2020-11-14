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

        public BaseTermsState(bool isLoading, bool current, int searchPageNr, long baseTermLangId, 
            long translationLangId, long baseTermId, long itemsPerPage, 
            string searchText, string token, string baseTermSlug,
            RootObject<ResultBaseTranslation> rootObject, ResultBaseTranslation resultBaseTranslation, EActionState lastActionState)
        {
            LastActionState = EActionState.Initializing;
            IsLoading = isLoading;
            Current = current;
            SearchPageNr = searchPageNr;
            BaseTermLangId = baseTermLangId;
            TranslationLangId = translationLangId;
            BaseTermId = baseTermId;
            ItemsPerPage = itemsPerPage;
            SearchText = searchText;
            Token = token;
            BaseTermSlug = baseTermSlug;
            RootObject = rootObject;
            ResultBaseTranslation = resultBaseTranslation;
            LastActionState = EActionState.Initialized;
        }

        public BaseTermsState(RootObject<ResultBaseTranslation> rootObject, EActionState lastActionState)
        {
            LastActionState = lastActionState;
            IsLoading = false;
            RootObject = rootObject ?? new RootObject<ResultBaseTranslation>();
        }

        public BaseTermsState(string searchText, long baseTermLangId, long translationLangId, 
            int searchPageNr, long itemsPerPage, bool current, EActionState lastActionState)
        {
            IsLoading = true;
            SearchText = searchText;
            BaseTermLangId = baseTermLangId;
            TranslationLangId = translationLangId;
            SearchPageNr = searchPageNr;
            ItemsPerPage = itemsPerPage;
            Current = current;
            LastActionState = lastActionState;
        }

        public BaseTermsState(BaseTerm baseTerm, string token, EActionState lastActionState)
        {
            IsLoading = true;
            BaseTerm = baseTerm;
            Token = token;
            LastActionState = lastActionState;
        }

        public BaseTermsState(long baseTermId, EActionState lastActionState)
        {
            IsLoading = true;
            BaseTermId = baseTermId;
            LastActionState = lastActionState;
        }

        public BaseTermsState(string baseTermSlug, EActionState lastActionState)
        {
            IsLoading = true;
            BaseTermSlug = baseTermSlug;
            LastActionState = lastActionState;
        }
        public BaseTermsState(BaseTerm baseTerm, List<OriinLink> links, EActionState lastActionState)
        {
            IsLoading = (lastActionState == EActionState.Updating || lastActionState == EActionState.FetchingOne);

            Links = links;
            BaseTerm = baseTerm;
            LastActionState = lastActionState;
        }

        public BaseTermsState(ResultBaseTranslation resultBaseTranslation, List<OriinLink> links, EActionState lastActionState)
        {
            IsLoading = (lastActionState == EActionState.Updating || lastActionState == EActionState.FetchingOne);

            ResultBaseTranslation = resultBaseTranslation;
            Links = links;
            LastActionState = lastActionState;
        }


    }

}