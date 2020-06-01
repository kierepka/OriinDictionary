using Fluxor;

namespace OriinDic.Store.Search
{
    public static class SearchReducers
    {
        [ReducerMethod]
        public static SearchState ReduceSearchBaseTermsAction(SearchState state, SearchBaseTermsAction action) =>
            new SearchState(searchText: action.SearchText, baseTermLangId: action.BaseTermLangId,
                            translationLangId: action.TranslationLangId,
                            searchPageNr: action.SearchPageNr, itemsPerPage: action.ItemsPerPage, 
                            current: action.Current, lastActionState: EActionState.FetchingData);
        
        [ReducerMethod]
        public static SearchState ReduceSearchBaseTermsResultAction(SearchState state, SearchBaseTermsResultAction action) =>
            new SearchState(rootObject: action.RootObject, lastActionState: EActionState.FetchedData);

        [ReducerMethod]
        public static SearchState ReduceSearchPageNrChangeAction(SearchState state, SearchPageNrChangeAction action) =>
            new SearchState(state, action.PageActionName);
        
        [ReducerMethod]
        public static SearchState ReduceSearchTranslationsAction(SearchState state, SearchTranslationsAction action) =>
            new SearchState(
                searchText: action.SearchText, baseTermLangId: action.BaseTermLangId, translationLangId: action.TranslationLangId,
                searchPageNr: action.SearchPageNr, itemsPerPage: action.ItemsPerPage, current: action.Current,
                lastActionState: EActionState.FetchingData);

        [ReducerMethod]
        public static SearchState ReduceSearchTranslationsResultAction(SearchState state, SearchTranslationsResultAction action) =>
            new SearchState(rootObject: action.RootObject, lastActionState: EActionState.FetchedData);
    }
}