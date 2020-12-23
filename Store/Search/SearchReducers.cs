using Fluxor;

namespace OriinDic.Store.Search
{
    public static class SearchReducers
    {
        [ReducerMethod]
        public static SearchState ReduceSearchBaseTermsAction(SearchState state, SearchBaseTermsAction action) =>
            new(
                rootObject: null,
                searchItems: state.SearchItems,
                localPages: state.LocalPages,
                currentLanguage1: state.CurrentLanguage1,
                currentLanguage2: state.CurrentLanguage2,
                confirmedResults: state.ConfirmedResults,
                currentBaseLangPl: state.CurrentBaseLangPl,
                buttonEnColor: state.ButtonEnColor,
                buttonPlColor: state.ButtonPlColor,
                searchPageNr: action.SearchPageNr,
                totalSearchItems: state.TotalSearchItems,
                totalPages: state.TotalPages,
                itemsPerPage: action.ItemsPerPage,
                translationLangId: action.TranslationLangId,
                baseTermLangId: action.BaseTermLangId,
                searchText: action.SearchText,
                noBaseTermName: state.NoBaseTermName,
                noTranslationName: state.NoTranslationName,
                noResults: state.NoResults,
                isLoading: state.IsLoading,
                current: action.Current,
                paginationShow: state.PaginationShow,
                lastActionState: EActionState.FetchingData);


        
        [ReducerMethod]
        public static SearchState ReduceSearchBaseTermsResultAction(SearchState state, SearchBaseTermsResultAction action) =>
            new(
                rootObject: action.RootObject,
                searchItems: state.SearchItems,
                localPages: state.LocalPages,
                currentLanguage1: state.CurrentLanguage1,
                currentLanguage2: state.CurrentLanguage2,
                confirmedResults: state.ConfirmedResults,
                currentBaseLangPl: state.CurrentBaseLangPl,
                buttonEnColor: state.ButtonEnColor,
                buttonPlColor: state.ButtonPlColor,
                searchPageNr: state.SearchPageNr,
                totalSearchItems: state.TotalSearchItems,
                totalPages: state.TotalPages,
                itemsPerPage: state.ItemsPerPage,
                translationLangId: state.TranslationLangId,
                baseTermLangId: state.BaseTermLangId,
                searchText: state.SearchText,
                noBaseTermName: state.NoBaseTermName,
                noTranslationName: state.NoTranslationName,
                noResults: state.NoResults,
                isLoading: state.IsLoading,
                current: state.Current,
                paginationShow: state.PaginationShow,
                lastActionState: EActionState.FetchedData);

        [ReducerMethod]
        public static SearchState ReduceSearchPageNrChangeAction(SearchState state, SearchPageNrChangeAction action) =>
            new(
                rootObject: null,
                searchItems: state.SearchItems,
                localPages: state.LocalPages,
                currentLanguage1: state.CurrentLanguage1,
                currentLanguage2: state.CurrentLanguage2,
                confirmedResults: state.ConfirmedResults,
                currentBaseLangPl: state.CurrentBaseLangPl,
                buttonEnColor: state.ButtonEnColor,
                buttonPlColor: state.ButtonPlColor,
                searchPageNr: action.SearchPageNr,
                totalSearchItems: state.TotalSearchItems,
                totalPages: state.TotalPages,
                itemsPerPage: action.ItemsPerPage,
                translationLangId: action.TranslationLangId,
                baseTermLangId: action.BaseTermLangId,
                searchText: action.SearchText,
                noBaseTermName: state.NoBaseTermName,
                noTranslationName: state.NoTranslationName,
                noResults: action.NoResults,
                isLoading: state.IsLoading,
                current: action.Current,
                paginationShow: state.PaginationShow,
                lastActionState: state.LastActionState);

        [ReducerMethod]
        public static SearchState ReduceSearchTranslationsAction(SearchState state, SearchTranslationsAction action) =>
            new(
                rootObject: null,
                searchItems: state.SearchItems,
                localPages: state.LocalPages,
                currentLanguage1: state.CurrentLanguage1,
                currentLanguage2: state.CurrentLanguage2,
                confirmedResults: state.ConfirmedResults,
                currentBaseLangPl: state.CurrentBaseLangPl,
                buttonEnColor: state.ButtonEnColor,
                buttonPlColor: state.ButtonPlColor,
                searchPageNr: action.SearchPageNr,
                totalSearchItems: state.TotalSearchItems,
                totalPages: state.TotalPages,
                itemsPerPage: action.ItemsPerPage,
                translationLangId: action.TranslationLangId,
                baseTermLangId: action.BaseTermLangId,
                searchText: action.SearchText,
                noBaseTermName: state.NoBaseTermName,
                noTranslationName: state.NoTranslationName,
                noResults: state.NoResults,
                isLoading: state.IsLoading,
                current: action.Current,
                paginationShow: state.PaginationShow,
                lastActionState: EActionState.FetchingData);

        [ReducerMethod]
        public static SearchState ReduceSearchTranslationsResultAction(SearchState state, SearchTranslationsResultAction action) =>
            new(
                rootObject: action.RootObject,
                searchItems: state.SearchItems,
                localPages: state.LocalPages,
                currentLanguage1: state.CurrentLanguage1,
                currentLanguage2: state.CurrentLanguage2,
                confirmedResults: state.ConfirmedResults,
                currentBaseLangPl: state.CurrentBaseLangPl,
                buttonEnColor: state.ButtonEnColor,
                buttonPlColor: state.ButtonPlColor,
                searchPageNr: state.SearchPageNr,
                totalSearchItems: state.TotalSearchItems,
                totalPages: state.TotalPages,
                itemsPerPage: state.ItemsPerPage,
                translationLangId: state.TranslationLangId,
                baseTermLangId: state.BaseTermLangId,
                searchText: state.SearchText,
                noBaseTermName: state.NoBaseTermName,
                noTranslationName: state.NoTranslationName,
                noResults: state.NoResults,
                isLoading: state.IsLoading,
                current: state.Current,
                paginationShow: state.PaginationShow,
                lastActionState: EActionState.FetchedData);
    }
}