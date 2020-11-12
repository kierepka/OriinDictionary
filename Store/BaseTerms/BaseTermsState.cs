using OriinDic.Models;

namespace OriinDic.Store.BaseTerms
{
    public class BaseTermsState
    {
        public EActionState LastActionState { get; private set; } 
        public string BaseTermSlug { get; private set; }
        public long BaseTermId { get; private set; } 
        public ResultBaseTranslation ResultBaseTranslation { get; private set; }
        public string Token { get; private set; } 
        public string SearchText { get; private set; } 
        public long BaseTermLangId { get; private set; } 
        public long TranslationLangId { get; private set; } 

        public int SearchPageNr { get; private set; } 
        public long ItemsPerPage { get; private set; } 
        public bool Current { get; private set; }
        public bool IsLoading { get; private set; } 
        public BaseTerm BaseTerm { get; private set; } 
        public RootObject<ResultBaseTranslation> RootObject { get; private set; } 

        public BaseTermsState()
        {
            BaseTermSlug = string.Empty;
            BaseTermId = long.MinValue;
            ResultBaseTranslation = new ResultBaseTranslation();
            Token = string.Empty;
            SearchText = string.Empty;
            BaseTermLangId = long.MinValue;
            TranslationLangId = long.MinValue;
            SearchPageNr = int.MinValue;
            ItemsPerPage = long.MinValue;
            Current = false;
            IsLoading = false;
            BaseTerm = new BaseTerm();
            RootObject = new RootObject<ResultBaseTranslation>();
        }

        public BaseTermsState(RootObject<ResultBaseTranslation> rootObject, EActionState lastActionState)
        {
            LastActionState = lastActionState;
            IsLoading = false;
            RootObject = rootObject ?? new RootObject<ResultBaseTranslation>();

            BaseTermSlug = string.Empty;
            BaseTermId = long.MinValue;
            ResultBaseTranslation = new ResultBaseTranslation();
            Token = string.Empty;
            SearchText = string.Empty;
            BaseTermLangId = long.MinValue;
            TranslationLangId = long.MinValue;
            SearchPageNr = int.MinValue;
            ItemsPerPage = long.MinValue;
            Current = false;
            BaseTerm = new BaseTerm();
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

            BaseTermSlug = string.Empty;
            BaseTermId = long.MinValue;
            ResultBaseTranslation = new ResultBaseTranslation();
            Token = string.Empty;
            BaseTerm = new BaseTerm();
            RootObject = new RootObject<ResultBaseTranslation>();
        }

        public BaseTermsState(BaseTerm baseTerm, string token, EActionState lastActionState)
        {
            IsLoading = true;
            BaseTerm = baseTerm;
            Token = token;
            LastActionState = lastActionState;

            BaseTermSlug = string.Empty;
            BaseTermId = long.MinValue;
            ResultBaseTranslation = new ResultBaseTranslation();
            Token = string.Empty;
            SearchText = string.Empty;
            BaseTermLangId = long.MinValue;
            TranslationLangId = long.MinValue;
            SearchPageNr = int.MinValue;
            ItemsPerPage = long.MinValue;
            Current = false;
            RootObject = new RootObject<ResultBaseTranslation>();

        }

        public BaseTermsState(long baseTermId, EActionState lastActionState)
        {
            IsLoading = true;
            BaseTermId = baseTermId;
            LastActionState = lastActionState;

            BaseTermSlug = string.Empty;
            ResultBaseTranslation = new ResultBaseTranslation();
            Token = string.Empty;
            SearchText = string.Empty;
            BaseTermLangId = long.MinValue;
            TranslationLangId = long.MinValue;
            SearchPageNr = int.MinValue;
            ItemsPerPage = long.MinValue;
            Current = false;
            BaseTerm = new BaseTerm();
            RootObject = new RootObject<ResultBaseTranslation>();

        }

        public BaseTermsState(string baseTermSlug, EActionState lastActionState)
        {
            IsLoading = true;
            BaseTermSlug = baseTermSlug;
            LastActionState = lastActionState;

            BaseTermId = long.MinValue;
            ResultBaseTranslation = new ResultBaseTranslation();
            Token = string.Empty;
            SearchText = string.Empty;
            BaseTermLangId = long.MinValue;
            TranslationLangId = long.MinValue;
            SearchPageNr = int.MinValue;
            ItemsPerPage = long.MinValue;
            Current = false;
            BaseTerm = new BaseTerm();
            RootObject = new RootObject<ResultBaseTranslation>();

        }
        public BaseTermsState(BaseTerm baseTerm, EActionState lastActionState)
        {
            IsLoading = (lastActionState == EActionState.Updating || lastActionState == EActionState.FetchingOne);

            BaseTerm = baseTerm;
            LastActionState = lastActionState;

            BaseTermSlug = string.Empty;
            BaseTermId = long.MinValue;
            ResultBaseTranslation = new ResultBaseTranslation();
            Token = string.Empty;
            SearchText = string.Empty;
            BaseTermLangId = long.MinValue;
            TranslationLangId = long.MinValue;
            SearchPageNr = int.MinValue;
            ItemsPerPage = long.MinValue;
            Current = false;
            RootObject = new RootObject<ResultBaseTranslation>();
        }

        public BaseTermsState(ResultBaseTranslation resultBaseTranslation, EActionState lastActionState)
        {
            IsLoading = (lastActionState == EActionState.Updating || lastActionState == EActionState.FetchingOne);

            ResultBaseTranslation = resultBaseTranslation;
            LastActionState = lastActionState;

            BaseTermSlug = string.Empty;
            BaseTermId = long.MinValue;
            Token = string.Empty;
            SearchText = string.Empty;
            BaseTermLangId = long.MinValue;
            TranslationLangId = long.MinValue;
            SearchPageNr = int.MinValue;
            ItemsPerPage = long.MinValue;
            Current = false;
            BaseTerm = new BaseTerm();
            RootObject = new RootObject<ResultBaseTranslation>();

        }


    }

}