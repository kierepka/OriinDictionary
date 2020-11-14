﻿using Fluxor;

using OriinDic.Models;

namespace OriinDic.Store.Translations
{
    public static class TranslationsReducers
    {

        [ReducerMethod]
        public static TranslationsState ReduceAddAction(TranslationsState state, TranslationsAddAction action) =>
            new TranslationsState(
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
                lastActionState: EActionState.Adding);

        [ReducerMethod]
        public static TranslationsState ReduceAddResultAction(TranslationsState state, TranslationsAddResultAction action) =>
            new TranslationsState(
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
                lastActionState: EActionState.Added);

        [ReducerMethod]
        public static TranslationsState ReduceFetchDataAction(TranslationsState state, TranslationsFetchDataAction action) =>
            new TranslationsState(
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
                comments: state.Comments,
                lastActionState: EActionState.FetchingData);

        [ReducerMethod]
        public static TranslationsState ReduceFetchDataResultAction(TranslationsState state, TranslationsFetchDataResultAction action) =>
            new TranslationsState(
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
                comments: state.Comments,
                lastActionState: EActionState.FetchedData);

        [ReducerMethod]
        public static TranslationsState ReduceFetchBaseTermAction(TranslationsState state, TranslationsFetchBaseTermAction action) =>
            new TranslationsState(
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
                comments: state.Comments,
                lastActionState: EActionState.FetchingBase);

        [ReducerMethod]
        public static TranslationsState ReduceFetchBaseTermResultAction(TranslationsState state, TranslationsFetchBaseTermResultAction action) =>
            new TranslationsState(
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
                baseTerm: action.BaseTerm,
                links: state.Links,
                comments: state.Comments,
                lastActionState: EActionState.FetchedBase);

        [ReducerMethod]
        public static TranslationsState ReduceFetchCommentsAction(TranslationsState state, TranslationsFetchCommentsAction action) =>
            new TranslationsState(
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
                links: state.Links,
                comments: state.Comments,
                lastActionState: EActionState.FetchingComments);

        [ReducerMethod]
        public static TranslationsState ReduceFetchCommentsResultAction(TranslationsState state, TranslationsFetchCommentsResultAction action) =>
            new TranslationsState(
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
                lastActionState: EActionState.FetchedComments);

        [ReducerMethod]
        public static TranslationsState ReduceFetchOneAction(TranslationsState state, TranslationsFetchOneAction action) =>
            new TranslationsState(
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
                lastActionState: EActionState.FetchingOne);

        [ReducerMethod]
        public static TranslationsState ReduceFetchOneResultAction(TranslationsState state, TranslationsFetchOneResultAction action) =>
            new TranslationsState(
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
                lastActionState: EActionState.FetchedOne);

        [ReducerMethod]
        public static TranslationsState ReduceFetch4EditAction(TranslationsState state, TranslationsFetch4EditAction action) =>
            new TranslationsState(
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
                lastActionState: EActionState.FetchingForEdit);

        [ReducerMethod]
        public static TranslationsState ReduceFetch4EditResultAction(TranslationsState state, TranslationsFetch4EditResultAction action) =>
            new TranslationsState(
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
                lastActionState: EActionState.FetchedForEdit);

        [ReducerMethod]
        public static TranslationsState ReduceUpdateAction(TranslationsState state, TranslationsUpdateAction action) =>
            new TranslationsState(
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
                links: state.Links,
                comments: state.Comments,
                lastActionState: EActionState.Updating);

        [ReducerMethod]
        public static TranslationsState ReduceUpdateResultAction(TranslationsState state, TranslationsUpdateResultAction action) =>
            new TranslationsState(
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
                lastActionState: EActionState.Updated);
    }
}