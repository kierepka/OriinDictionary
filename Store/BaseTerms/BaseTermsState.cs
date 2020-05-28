using OriinDic.Models;

namespace OriinDic.Store.BaseTerms
{
    public class BaseTermsState
    {
        public EActionState LastActionState { get; }
        public string BaseTermSlug { get; }
        public long BaseTermId { get; }
        public BaseTerm? BaseTerm { get; }
        public string Token { get; }
        public string SearchText { get; }
        public long BaseTermLangId { get; }
        public long TranslationLangId { get; }
        
        public int SearchPageNr { get; }
        public long ItemsPerPage { get; }
        public bool Current { get; }
        public bool IsLoading { get; }
        public RootObject<ResultBaseTranslation>? RootObject { get; }

        public BaseTermsState(bool isLoading, bool current, int searchPageNr, long baseTermLangId, 
            long translationLangId, long baseTermId, long itemsPerPage, 
            string searchText, string token, string baseTermSlug,
            RootObject<ResultBaseTranslation>? rootObject, BaseTerm? baseTerm)
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
            BaseTerm = baseTerm;
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
        public BaseTermsState(BaseTerm baseTerm, EActionState lastActionState)
        {
            IsLoading = (lastActionState == EActionState.Updating || lastActionState == EActionState.FetchingOne);
            
            BaseTerm = baseTerm;
            LastActionState = lastActionState;
        }


    }

}