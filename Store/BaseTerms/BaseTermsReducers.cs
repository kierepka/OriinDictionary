using Fluxor;

namespace OriinDic.Store.BaseTerms
{
    public static class BaseTermsReducers
    {

        [ReducerMethod]
        public static BaseTermsState ReduceAddAction(BaseTermsState state, BaseTermsAddAction baseTermAction) =>
            new BaseTermsState(
                baseTerm: baseTermAction.BaseTerm,
                token: baseTermAction.Token,
                lastActionState: EActionState.Adding);
        [ReducerMethod]
        public static BaseTermsState ReduceAddResultAction(BaseTermsState state, BaseTermsAddResultAction baseTermAction) =>
            new BaseTermsState(baseTerm: baseTermAction.BaseTerm, lastActionState: EActionState.Added);

        [ReducerMethod]
        public static BaseTermsState ReduceFetchDataAction(BaseTermsState state, BaseTermsFetchDataAction action) =>
            new BaseTermsState(searchText: action.SearchText, baseTermLangId: action.BaseTermLangId, translationLangId: action.TranslationLangId,
                            searchPageNr: action.SearchPageNr, itemsPerPage: action.ItemsPerPage, current: action.Current,
                            lastActionState: EActionState.FetchingData);
        [ReducerMethod]
        public static BaseTermsState ReduceFetchDataResultAction(BaseTermsState state, BaseTermsFetchDataResultAction action) =>
            new BaseTermsState(rootObject: action.RootObject, lastActionState: EActionState.FetchedData);

        [ReducerMethod]
        public static BaseTermsState ReduceFetchOneAction(BaseTermsState state, BaseTermsFetchOneAction action) =>
            new BaseTermsState(baseTermId: action.BaseTermId, lastActionState: EActionState.FetchingOne);

        [ReducerMethod]
        public static BaseTermsState ReduceFetchOneResultAction(BaseTermsState state, BaseTermsFetchOneResultAction action) =>
            new BaseTermsState(baseTerm: action.BaseTerm, lastActionState: EActionState.FetchedOne);

        [ReducerMethod]
        public static BaseTermsState ReduceFetchOneSlugAction(BaseTermsState state, BaseTermsFetchOneSlugAction action) =>
            new BaseTermsState(baseTermSlug: action.Slug, lastActionState: EActionState.FetchingOne);

        [ReducerMethod]
        public static BaseTermsState ReduceFetchOneSlugResultAction(BaseTermsState state, BaseTermsFetchOneSlugResultAction action) =>
            new BaseTermsState(baseTerm: action.BaseTerm, lastActionState: EActionState.FetchedOne);

        [ReducerMethod]
        public static BaseTermsState ReduceUpdateAction(BaseTermsState state, BaseTermsUpdateAction action) =>
            new BaseTermsState(baseTerm: action.BaseTerm, token: action.Token, lastActionState: EActionState.Updating);

        [ReducerMethod]
        public static BaseTermsState ReduceUpdateResultAction(BaseTermsState state, BaseTermsUpdateResultAction action) =>
            new BaseTermsState(baseTerm: action.BaseTerm, lastActionState: EActionState.Updated);
    }
}