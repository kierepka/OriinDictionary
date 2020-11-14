using Fluxor;

namespace OriinDic.Store.BaseTerms
{
    public static class BaseTermsReducers
    {

        [ReducerMethod]
        public static BaseTermsState ReduceAddAction(BaseTermsState state, BaseTermsAddAction baseTermAction) =>
            new BaseTermsState(
                isLoading: state.IsLoading,
                current: state.Current,
                searchPageNr: state.SearchPageNr,
                baseTermLangId: state.BaseTermLangId,
                translationLangId: state.TranslationLangId,
                baseTermId: state.BaseTermId,
                itemsPerPage: state.ItemsPerPage,
                searchText: state.SearchText,
                token: baseTermAction.Token,                
                baseTermSlug: state.BaseTermSlug,
                baseTerm: baseTermAction.BaseTerm,
                rootObject: state.RootObject,
                resultBaseTranslation: state.ResultBaseTranslation,
                links: state.Links,
                lastActionState: EActionState.Adding);



        [ReducerMethod]
        public static BaseTermsState ReduceAddResultAction(BaseTermsState state, BaseTermsAddResultAction baseTermAction) =>
            new BaseTermsState(
                isLoading: state.IsLoading,
                current: state.Current,
                searchPageNr: state.SearchPageNr,
                baseTermLangId: state.BaseTermLangId,
                translationLangId: state.TranslationLangId,
                baseTermId: state.BaseTermId,
                itemsPerPage: state.ItemsPerPage,
                searchText: state.SearchText,
                token: state.Token,
                baseTermSlug: state.BaseTermSlug,
                baseTerm: baseTermAction.BaseTerm,
                rootObject: state.RootObject,
                resultBaseTranslation: state.ResultBaseTranslation,
                links: state.Links,
                lastActionState: EActionState.Added);


        [ReducerMethod]
        public static BaseTermsState ReduceFetchDataAction(BaseTermsState state, BaseTermsFetchDataAction action) =>
            new BaseTermsState(
                isLoading: state.IsLoading,
                current: action.Current,
                searchPageNr: action.SearchPageNr,
                baseTermLangId: action.BaseTermLangId,
                translationLangId: action.TranslationLangId,
                baseTermId: state.BaseTermId,
                itemsPerPage: action.ItemsPerPage,
                searchText: action.SearchText,
                token: state.Token,
                baseTermSlug: state.BaseTermSlug,
                baseTerm: state.BaseTerm,
                rootObject: state.RootObject,
                resultBaseTranslation: state.ResultBaseTranslation,
                links: state.Links,
                lastActionState: EActionState.FetchingData);

      
        [ReducerMethod]
        public static BaseTermsState ReduceFetchDataResultAction(BaseTermsState state, BaseTermsFetchDataResultAction action) =>
             new BaseTermsState(
                isLoading: state.IsLoading,
                current: state.Current,
                searchPageNr: state.SearchPageNr,
                baseTermLangId: state.BaseTermLangId,
                translationLangId: state.TranslationLangId,
                baseTermId: state.BaseTermId,
                itemsPerPage: state.ItemsPerPage,
                searchText: state.SearchText,
                token: state.Token,
                baseTermSlug: state.BaseTermSlug,
                baseTerm: state.BaseTerm,
                rootObject: action.RootObject,
                resultBaseTranslation: state.ResultBaseTranslation,
                links: state.Links,
                lastActionState: EActionState.FetchedData);

        [ReducerMethod]
        public static BaseTermsState ReduceFetchOneAction(BaseTermsState state, BaseTermsFetchOneAction action) =>
            new BaseTermsState(
                isLoading: state.IsLoading,
                current: state.Current,
                searchPageNr: state.SearchPageNr,
                baseTermLangId: state.BaseTermLangId,
                translationLangId: state.TranslationLangId,
                baseTermId: action.BaseTermId,
                itemsPerPage: state.ItemsPerPage,
                searchText: state.SearchText,
                token: state.Token,
                baseTermSlug: state.BaseTermSlug,
                baseTerm: state.BaseTerm,
                rootObject: state.RootObject,
                resultBaseTranslation: state.ResultBaseTranslation,
                links: state.Links,
                lastActionState: EActionState.FetchingOne);

        [ReducerMethod]
        public static BaseTermsState ReduceFetchOneResultAction(BaseTermsState state, BaseTermsFetchOneResultAction action) =>
            new BaseTermsState(
                isLoading: state.IsLoading,
                current: state.Current,
                searchPageNr: state.SearchPageNr,
                baseTermLangId: state.BaseTermLangId,
                translationLangId: state.TranslationLangId,
                baseTermId: state.BaseTermId,
                itemsPerPage: state.ItemsPerPage,
                searchText: state.SearchText,
                token: state.Token,
                baseTermSlug: state.BaseTermSlug,
                baseTerm: state.BaseTerm,
                rootObject: state.RootObject,
                resultBaseTranslation: action.BaseTranslation,
                links: action.Links,
                lastActionState: EActionState.FetchedOne);


        [ReducerMethod]
        public static BaseTermsState ReduceFetchOneSlugAction(BaseTermsState state, BaseTermsFetchOneSlugAction action) =>
            new BaseTermsState(
                isLoading: state.IsLoading,
                current: state.Current,
                searchPageNr: state.SearchPageNr,
                baseTermLangId: state.BaseTermLangId,
                translationLangId: state.TranslationLangId,
                baseTermId: state.BaseTermId,
                itemsPerPage: state.ItemsPerPage,
                searchText: state.SearchText,
                token: state.Token,
                baseTermSlug: action.Slug,
                baseTerm: state.BaseTerm,
                rootObject: state.RootObject,
                resultBaseTranslation: state.ResultBaseTranslation,
                links: state.Links,
                lastActionState: EActionState.FetchingOne);


        [ReducerMethod]
        public static BaseTermsState ReduceFetchOneSlugResultAction(BaseTermsState state, BaseTermsFetchOneSlugResultAction action) =>
            new BaseTermsState(
                isLoading: state.IsLoading,
                current: state.Current,
                searchPageNr: state.SearchPageNr,
                baseTermLangId: state.BaseTermLangId,
                translationLangId: state.TranslationLangId,
                baseTermId: state.BaseTermId,
                itemsPerPage: state.ItemsPerPage,
                searchText: state.SearchText,
                token: state.Token,
                baseTermSlug: state.BaseTermSlug,
                baseTerm: action.BaseTerm,
                rootObject: state.RootObject,
                resultBaseTranslation: state.ResultBaseTranslation,
                links: action.Links,
                lastActionState: EActionState.FetchedOne);

        [ReducerMethod]
        public static BaseTermsState ReduceUpdateAction(BaseTermsState state, BaseTermsUpdateAction action) =>
            new BaseTermsState(
                isLoading: state.IsLoading,
                current: state.Current,
                searchPageNr: state.SearchPageNr,
                baseTermLangId: state.BaseTermLangId,
                translationLangId: state.TranslationLangId,
                baseTermId: state.BaseTermId,
                itemsPerPage: state.ItemsPerPage,
                searchText: state.SearchText,
                token: action.Token,
                baseTermSlug: state.BaseTermSlug,
                baseTerm: action.BaseTerm,
                rootObject: state.RootObject,
                resultBaseTranslation: state.ResultBaseTranslation,
                links: state.Links,
                lastActionState: EActionState.Updating);


        [ReducerMethod]
        public static BaseTermsState ReduceUpdateResultAction(BaseTermsState state, BaseTermsUpdateResultAction action) =>
            new BaseTermsState(
                isLoading: state.IsLoading,
                current: state.Current,
                searchPageNr: state.SearchPageNr,
                baseTermLangId: state.BaseTermLangId,
                translationLangId: state.TranslationLangId,
                baseTermId: state.BaseTermId,
                itemsPerPage: state.ItemsPerPage,
                searchText: state.SearchText,
                token: state.Token,
                baseTermSlug: state.BaseTermSlug,
                baseTerm: action.BaseTerm,
                rootObject: state.RootObject,
                resultBaseTranslation: state.ResultBaseTranslation,
                links: state.Links,
                lastActionState: EActionState.Updated);

    }
}