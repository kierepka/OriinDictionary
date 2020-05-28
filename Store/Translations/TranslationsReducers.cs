using Fluxor;

namespace OriinDic.Store.Translations
{
    public static class TranslationsReducers
    {

        [ReducerMethod]
        public static TranslationsState ReduceAddAction(TranslationsState state, TranslationsAddAction action) =>
            new TranslationsState(
                translation: action.Translation,
                lastActionState: EActionState.Adding);

        [ReducerMethod]
        public static TranslationsState ReduceAddResultAction(TranslationsState state, TranslationsAddResultAction action) =>
            new TranslationsState(
                translation: action.Translation, 
                lastActionState: EActionState.Added);

        [ReducerMethod]
        public static TranslationsState ReduceFetchDataAction(TranslationsState state, TranslationsFetchDataAction action) =>
            new TranslationsState(
                searchText: action.SearchText, baseTermLangId: action.BaseTermLangId, langId: action.LangId,
                searchPageNr: action.SearchPageNr, itemsPerPage: action.ItemsPerPage, current: action.Current,
                lastActionState: EActionState.FetchingData);

        [ReducerMethod]
        public static TranslationsState ReduceFetchDataResultAction(TranslationsState state, TranslationsFetchDataResultAction action) =>
            new TranslationsState(rootObject: action.RootObject, lastActionState: EActionState.FetchedData);

        [ReducerMethod]
        public static TranslationsState ReduceFetchBaseTermAction(TranslationsState state, TranslationsFetchBaseTermAction action) =>
            new TranslationsState(baseTermId: action.BaseTermId, isBaseTermId: true, lastActionState: EActionState.FetchingBase);

        [ReducerMethod]
        public static TranslationsState ReduceFetchBaseTermResultAction(TranslationsState state, TranslationsFetchBaseTermResultAction action) =>
            new TranslationsState(baseTerm: action.BaseTerm, lastActionState: EActionState.FetchedBase);

        [ReducerMethod]
        public static TranslationsState ReduceFetchCommentsAction(TranslationsState state, TranslationsFetchCommentsAction action) =>
            new TranslationsState(translationId: action.TranslationId, token: action.Token, lastActionState: EActionState.FetchingComments);

        [ReducerMethod]
        public static TranslationsState ReduceFetchCommentsResultAction(TranslationsState state, TranslationsFetchCommentsResultAction action) =>
            new TranslationsState(comments: action.Comments, lastActionState: EActionState.FetchedComments);

        [ReducerMethod]
        public static TranslationsState ReduceFetchOneAction(TranslationsState state, TranslationsFetchOneAction action) =>
            new TranslationsState(translationId: action.TranslationId, lastActionState: EActionState.FetchingOne);

        [ReducerMethod]
        public static TranslationsState ReduceFetchOneResultAction(TranslationsState state, TranslationsFetchOneResultAction action) =>
            new TranslationsState(translation: action.Translation, lastActionState: EActionState.FetchedOne);

        [ReducerMethod]
        public static TranslationsState ReduceFetch4EditAction(TranslationsState state, TranslationsFetch4EditAction action) =>
            new TranslationsState(translationId: action.TranslationId, lastActionState:EActionState.FetchingForEdit);

        [ReducerMethod]
        public static TranslationsState ReduceFetch4EditResultAction(TranslationsState state, TranslationsFetch4EditResultAction action) =>
            new TranslationsState(translation: action.Translation, baseTerm: action.BaseTerm, links: action.Links,
                comments: action.Comments, lastActionState: EActionState.FetchedForEdit);

        [ReducerMethod]
        public static TranslationsState ReduceUpdateAction(TranslationsState state, TranslationsUpdateAction action) =>
            new TranslationsState(
             action.TranslationId, action.Translation, action.Token, lastActionState: EActionState.Updating);
        
        [ReducerMethod]
        public static TranslationsState ReduceUpdateResultAction(TranslationsState state, TranslationsUpdateResultAction action) =>
            new TranslationsState(translation: action.Translation, lastActionState: EActionState.Updated);
    }
}