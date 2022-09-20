using Fluxor;

namespace OriinDictionary7.Store.Translations;

public static class TranslationsReducers
{


    [ReducerMethod]
    public static TranslationsState ReduceApproveAction(TranslationsState state, TranslationsApproveAction action) =>
     new(
         current: state.Current,
         isLoading: state.IsLoading,
         searchText: state.SearchText,
         token: state.Token,
         translationId: action.TranslationId,
         baseTermId: state.BaseTermId,
         baseTermLangId: state.BaseTermLangId,
         langId: state.LangId,
         itemsPerPage: state.ItemsPerPage,
         searchPageNr: state.SearchPageNr,
         rootObject: state.RootObject,
         baseTranslation: state.BaseTranslation,
         translation: state.Translation,
         baseTerm: state.BaseTerm,
         links: state.Links,
         comments: state.Comments,
         resultCode: state.ResultCode,
         lastActionState: EActionState.Updating);

    [ReducerMethod]
    public static TranslationsState ReduceAddResultAction(TranslationsState state, TranslationsApproveResultAction action) =>
        new(
            current: state.Current,
            isLoading: state.IsLoading,
            searchText: state.SearchText,
            token: state.Token,
            translationId: state.TranslationId,
            baseTermId: state.BaseTermId,
            baseTermLangId: state.BaseTermLangId,
            langId: state.LangId,
            itemsPerPage: state.ItemsPerPage,
            searchPageNr: state.SearchPageNr,
            rootObject: state.RootObject,
            baseTranslation: state.BaseTranslation,
            translation: action.Translation,
            baseTerm: state.BaseTerm,
            links: state.Links,
            resultCode: action.ResultCode,
            comments: state.Comments,
            lastActionState: EActionState.Updated);


    [ReducerMethod]
    public static TranslationsState ReduceAddAction(TranslationsState state, TranslationsAddAction action) =>
        new(
            current: state.Current,
            isLoading: state.IsLoading,
            searchText: state.SearchText,
            token: state.Token,
            translationId: state.TranslationId,
            baseTermId: state.BaseTermId,
            baseTermLangId: state.BaseTermLangId,
            langId: state.LangId,
            itemsPerPage: state.ItemsPerPage,
            searchPageNr: state.SearchPageNr,
            rootObject: state.RootObject,
            baseTranslation: state.BaseTranslation,
            translation: action.Translation,
            baseTerm: state.BaseTerm,
            links: state.Links,
            comments: state.Comments,
            resultCode: state.ResultCode,
            lastActionState: EActionState.Adding);

    [ReducerMethod]
    public static TranslationsState ReduceAddResultAction(TranslationsState state, TranslationsAddResultAction action) =>
        new(
            current: state.Current,
            isLoading: state.IsLoading,
            searchText: state.SearchText,
            token: state.Token,
            translationId: state.TranslationId,
            baseTermId: state.BaseTermId,
            baseTermLangId: state.BaseTermLangId,
            langId: state.LangId,
            itemsPerPage: state.ItemsPerPage,
            searchPageNr: state.SearchPageNr,
            rootObject: state.RootObject,
            baseTranslation: state.BaseTranslation,
            translation: action.Translation,
            baseTerm: state.BaseTerm,
            links: state.Links,
            resultCode: action.ResultCode,
            comments: state.Comments,
            lastActionState: EActionState.Added);

    [ReducerMethod]
    public static TranslationsState ReduceFetchDataAction(TranslationsState state, TranslationsFetchDataAction action) =>
        new(
            current: action.Current,
            isLoading: state.IsLoading,
            searchText: action.SearchText,
            token: state.Token,
            translationId: state.TranslationId,
            baseTermId: state.BaseTermId,
            baseTermLangId: action.BaseTermLangId,
            langId: action.LangId,
            itemsPerPage: action.ItemsPerPage,
            searchPageNr: action.SearchPageNr,
            rootObject: state.RootObject,
            baseTranslation: state.BaseTranslation,
            translation: state.Translation,
            baseTerm: state.BaseTerm,
            links: state.Links,
             resultCode: state.ResultCode,
            comments: state.Comments,
            lastActionState: EActionState.FetchingData);

    [ReducerMethod]
    public static TranslationsState ReduceFetchDataResultAction(TranslationsState state, TranslationsFetchDataResultAction action) =>
        new(
            current: state.Current,
            isLoading: state.IsLoading,
            searchText: state.SearchText,
            token: state.Token,
            translationId: state.TranslationId,
            baseTermId: state.BaseTermId,
            baseTermLangId: state.BaseTermLangId,
            langId: state.LangId,
            itemsPerPage: state.ItemsPerPage,
            searchPageNr: state.SearchPageNr,
            rootObject: action.RootObject,
            baseTranslation: state.BaseTranslation,
            translation: state.Translation,
            baseTerm: state.BaseTerm,
            links: state.Links,
            resultCode: action.ResultCode,
            comments: state.Comments,
            lastActionState: EActionState.FetchedData);

    [ReducerMethod]
    public static TranslationsState ReduceFetchBaseTermAction(TranslationsState state, TranslationsFetchBaseTermAction action) =>
        new(
            current: state.Current,
            isLoading: state.IsLoading,
            searchText: state.SearchText,
            token: state.Token,
            translationId: state.TranslationId,
            baseTermId: action.BaseTermId,
            baseTermLangId: state.BaseTermLangId,
            langId: state.LangId,
            itemsPerPage: state.ItemsPerPage,
            searchPageNr: state.SearchPageNr,
            rootObject: state.RootObject,
            baseTranslation: state.BaseTranslation,
            translation: state.Translation,
            baseTerm: state.BaseTerm,
            links: state.Links,
             resultCode: state.ResultCode,
            comments: state.Comments,
            lastActionState: EActionState.FetchingBase);

    [ReducerMethod]
    public static TranslationsState ReduceFetchBaseTermResultAction(TranslationsState state, TranslationsFetchBaseTermResultAction action) =>
        new(
            current: state.Current,
            isLoading: state.IsLoading,
            searchText: state.SearchText,
            token: state.Token,
            translationId: state.TranslationId,
            baseTermId: state.BaseTermId,
            baseTermLangId: state.BaseTermLangId,
            langId: state.LangId,
            itemsPerPage: state.ItemsPerPage,
            searchPageNr: state.SearchPageNr,
            rootObject: state.RootObject,
            baseTranslation: action.BaseTranslation,
            translation: state.Translation,
            baseTerm: state.BaseTerm,
            links: state.Links,
            resultCode: action.ResultCode,
            comments: state.Comments,
            lastActionState: EActionState.FetchedBase);

    [ReducerMethod]
    public static TranslationsState ReduceFetchCommentsAction(TranslationsState state, TranslationsFetchCommentsAction action) =>
        new(
            current: state.Current,
            isLoading: state.IsLoading,
            searchText: state.SearchText,
            token: action.Token,
            translationId: action.TranslationId,
            baseTermId: state.BaseTermId,
            baseTermLangId: state.BaseTermLangId,
            langId: state.LangId,
            itemsPerPage: state.ItemsPerPage,
            searchPageNr: state.SearchPageNr,
            rootObject: state.RootObject,
            baseTranslation: state.BaseTranslation,
            translation: state.Translation,
            baseTerm: state.BaseTerm,
             resultCode: state.ResultCode,
            links: state.Links,
            comments: state.Comments,
            lastActionState: EActionState.FetchingComments);

    [ReducerMethod]
    public static TranslationsState ReduceFetchCommentsResultAction(TranslationsState state, TranslationsFetchCommentsResultAction action) =>
        new(
            current: state.Current,
            isLoading: state.IsLoading,
            searchText: state.SearchText,
            token: state.Token,
            translationId: state.TranslationId,
            baseTermId: state.BaseTermId,
            baseTermLangId: state.BaseTermLangId,
            langId: state.LangId,
            itemsPerPage: state.ItemsPerPage,
            searchPageNr: state.SearchPageNr,
            rootObject: state.RootObject,
            baseTranslation: state.BaseTranslation,
            translation: state.Translation,
            baseTerm: state.BaseTerm,
            links: state.Links,
            comments: action.Comments,
            resultCode: action.ResultCode,
            lastActionState: EActionState.FetchedComments);

    [ReducerMethod]
    public static TranslationsState ReduceFetchOneAction(TranslationsState state, TranslationsFetchOneAction action) =>
        new(
            current: state.Current,
            isLoading: state.IsLoading,
            searchText: state.SearchText,
            token: state.Token,
            translationId: action.TranslationId,
            baseTermId: state.BaseTermId,
            baseTermLangId: state.BaseTermLangId,
            langId: state.LangId,
            itemsPerPage: state.ItemsPerPage,
            searchPageNr: state.SearchPageNr,
            rootObject: state.RootObject,
            baseTranslation: state.BaseTranslation,
            translation: state.Translation,
            baseTerm: state.BaseTerm,
            links: state.Links,
             resultCode: state.ResultCode,
            comments: state.Comments,
            lastActionState: EActionState.FetchingOne);

    [ReducerMethod]
    public static TranslationsState ReduceFetchOneResultAction(TranslationsState state, TranslationsFetchOneResultAction action) =>
        new(
            current: state.Current,
            isLoading: state.IsLoading,
            searchText: state.SearchText,
            token: state.Token,
            translationId: state.TranslationId,
            baseTermId: state.BaseTermId,
            baseTermLangId: state.BaseTermLangId,
            langId: state.LangId,
            itemsPerPage: state.ItemsPerPage,
            searchPageNr: state.SearchPageNr,
            rootObject: state.RootObject,
            baseTranslation: state.BaseTranslation,
            translation: action.Translation,
            baseTerm: state.BaseTerm,
            links: state.Links,
            comments: state.Comments,
            resultCode: action.ResultCode,
            lastActionState: EActionState.FetchedOne);

    [ReducerMethod]
    public static TranslationsState ReduceFetch4EditAction(TranslationsState state, TranslationsFetch4EditAction action) =>
        new(
            current: state.Current,
            isLoading: state.IsLoading,
            searchText: state.SearchText,
            token: state.Token,
            translationId: action.TranslationId,
            baseTermId: state.BaseTermId,
            baseTermLangId: state.BaseTermLangId,
            langId: state.LangId,
            itemsPerPage: state.ItemsPerPage,
            searchPageNr: state.SearchPageNr,
            rootObject: state.RootObject,
            baseTranslation: state.BaseTranslation,
            translation: state.Translation,
            baseTerm: state.BaseTerm,
            resultCode: state.ResultCode,
            links: state.Links,
            comments: state.Comments,
            lastActionState: EActionState.FetchingForEdit);

    [ReducerMethod]
    public static TranslationsState ReduceFetch4EditResultAction(TranslationsState state, TranslationsFetch4EditResultAction action) =>
        new(
            current: state.Current,
            isLoading: state.IsLoading,
            searchText: state.SearchText,
            token: state.Token,
            translationId: state.TranslationId,
            baseTermId: state.BaseTermId,
            baseTermLangId: state.BaseTermLangId,
            langId: state.LangId,
            itemsPerPage: state.ItemsPerPage,
            searchPageNr: state.SearchPageNr,
            rootObject: state.RootObject,
            baseTranslation: state.BaseTranslation,
            translation: action.Translation,
            baseTerm: action.BaseTerm,
            links: action.Links,
            comments: action.Comments,
            resultCode: action.ResultCode,
            lastActionState: EActionState.FetchedForEdit);

    [ReducerMethod]
    public static TranslationsState ReduceUpdateAction(TranslationsState state, TranslationsUpdateAction action) =>
        new(
            current: state.Current,
            isLoading: state.IsLoading,
            searchText: state.SearchText,
            token: action.Token,
            translationId: action.TranslationId,
            baseTermId: state.BaseTermId,
            baseTermLangId: state.BaseTermLangId,
            langId: state.LangId,
            itemsPerPage: state.ItemsPerPage,
            searchPageNr: state.SearchPageNr,
            rootObject: state.RootObject,
            baseTranslation: state.BaseTranslation,
            translation: action.Translation,
            baseTerm: state.BaseTerm,
             resultCode: state.ResultCode,
            links: state.Links,
            comments: state.Comments,
            lastActionState: EActionState.Updating);

    [ReducerMethod]
    public static TranslationsState ReduceUpdateResultAction(TranslationsState state, TranslationsUpdateResultAction action) =>
        new(
            current: state.Current,
            isLoading: state.IsLoading,
            searchText: state.SearchText,
            token: state.Token,
            translationId: state.TranslationId,
            baseTermId: state.BaseTermId,
            baseTermLangId: state.BaseTermLangId,
            langId: state.LangId,
            itemsPerPage: state.ItemsPerPage,
            searchPageNr: state.SearchPageNr,
            rootObject: state.RootObject,
            baseTranslation: state.BaseTranslation,
            translation: action.Translation,
            baseTerm: state.BaseTerm,
            links: state.Links,
            comments: state.Comments,
            resultCode: action.ResultCode,
            lastActionState: EActionState.Updated);
}