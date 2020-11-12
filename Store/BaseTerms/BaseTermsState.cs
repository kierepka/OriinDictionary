using OriinDic.Models;

using System.Runtime.CompilerServices;

namespace OriinDic.Store.BaseTerms
{
    public class BaseTermsState
    {
        public EActionState LastActionState { get; init; } = EActionState.Initializing;
        public string BaseTermSlug { get; init; } = string.Empty;
        public long BaseTermId { get; init; } = long.MinValue;
        public ResultBaseTranslation ResultBaseTranslation { get; init; } = new ResultBaseTranslation();
        public string Token { get; init; } = string.Empty;
        public string SearchText { get; init; } = string.Empty;
        public long BaseTermLangId { get; init; } = long.MinValue;
        public long TranslationLangId { get; init; } = long.MinValue;

        public int SearchPageNr { get; init; } = int.MinValue;
        public long ItemsPerPage { get; init; } = long.MinValue;
        public bool Current { get; init; } = false;
        public bool IsLoading { get; init; } = false;
        public BaseTerm BaseTerm { get; init; } = new BaseTerm();
        public RootObject<ResultBaseTranslation> RootObject { get; init; } = new RootObject<ResultBaseTranslation>();

        public BaseTermsState()
        {
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

        public BaseTermsState(ResultBaseTranslation resultBaseTranslation, EActionState lastActionState)
        {
            IsLoading = (lastActionState == EActionState.Updating || lastActionState == EActionState.FetchingOne);

            ResultBaseTranslation = resultBaseTranslation;
            LastActionState = lastActionState;

        }


    }

}