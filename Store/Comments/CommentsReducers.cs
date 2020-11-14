using Fluxor;

namespace OriinDic.Store.Comments
{
    public static class CommentsReducers
    {

        [ReducerMethod]
        public static CommentsState ReduceAddAction(CommentsState state, CommentsAddAction action) =>
            new CommentsState(
                isLoading: state.IsLoading,
                searchPageNr: state.SearchPageNr,
                itemsPerPage: state.ItemsPerPage,
                commentId: state.CommentId,
                translationId: state.TranslationId,
                token: state.Token,
                statusCode: state.StatusCode,
                comment: action.Comment,
                rootObject: state.RootObject,
                deleteResponse: state.DeleteResponse,
                lastActionState: EActionState.Adding);


        [ReducerMethod]
        public static CommentsState ReduceAddResultAction(CommentsState state, CommentsAddResultAction action) =>
            new CommentsState(
                isLoading: state.IsLoading,
                searchPageNr: state.SearchPageNr,
                itemsPerPage: state.ItemsPerPage,
                commentId: state.CommentId,
                translationId: state.TranslationId,
                token: state.Token,
                statusCode: action.StatusCode,
                comment: action.Comment,
                rootObject: state.RootObject,
                deleteResponse: state.DeleteResponse,
                lastActionState: EActionState.Added);



        [ReducerMethod]
        public static CommentsState ReduceDeleteAction(CommentsState state, CommentsDeleteAction action) =>
            new CommentsState(
                isLoading: state.IsLoading,
                searchPageNr: state.SearchPageNr,
                itemsPerPage: state.ItemsPerPage,
                commentId: action.CommentId,
                translationId: state.TranslationId,
                token: state.Token,
                statusCode: state.StatusCode,
                comment: state.Comment,
                rootObject: state.RootObject,
                deleteResponse: state.DeleteResponse,
                lastActionState: EActionState.Deleting);


        [ReducerMethod]
        public static CommentsState ReduceDeleteResultAction(CommentsState state, CommentsDeleteResultAction action) =>
            new CommentsState(
                isLoading: state.IsLoading,
                searchPageNr: state.SearchPageNr,
                itemsPerPage: state.ItemsPerPage,
                commentId: state.CommentId,
                translationId: state.TranslationId,
                token: state.Token,
                statusCode: state.StatusCode,
                comment: state.Comment,
                rootObject: state.RootObject,
                deleteResponse: action.DeleteResponse,
                lastActionState: EActionState.Deleted);


        [ReducerMethod]
        public static CommentsState ReduceFetchDataAction(CommentsState state, CommentsFetchDataAction action) =>
            new CommentsState(
                isLoading: state.IsLoading,
                searchPageNr: action.SearchPageNr,
                itemsPerPage: action.ItemsPerPage,
                commentId: state.CommentId,
                translationId: state.TranslationId,
                token: action.Token,
                statusCode: state.StatusCode,
                comment: state.Comment,
                rootObject: state.RootObject,
                deleteResponse: state.DeleteResponse,
                lastActionState: EActionState.FetchingData);


        [ReducerMethod]
        public static CommentsState ReduceFetchDataResultAction(CommentsState state, CommentsFetchDataResultAction action) =>
            new CommentsState(
                isLoading: state.IsLoading,
                searchPageNr: state.SearchPageNr,
                itemsPerPage: state.ItemsPerPage,
                commentId: state.CommentId,
                translationId: state.TranslationId,
                token: state.Token,
                statusCode: state.StatusCode,
                comment: state.Comment,
                rootObject: action.RootObject,
                deleteResponse: state.DeleteResponse,
                lastActionState: EActionState.FetchedData);



        [ReducerMethod]
        public static CommentsState ReduceFetchForTranslationAction(CommentsState state, CommentsFetchForTranslationAction action) =>
            new CommentsState(
                isLoading: state.IsLoading,
                searchPageNr: state.SearchPageNr,
                itemsPerPage: state.ItemsPerPage,
                commentId: state.CommentId,
                translationId: action.TranslationId,
                token: action.Token,
                statusCode: state.StatusCode,
                comment: state.Comment,
                rootObject: state.RootObject,
                deleteResponse: state.DeleteResponse,
                lastActionState: EActionState.FetchingForTranslation);


        [ReducerMethod]
        public static CommentsState ReduceFetchOneAction(CommentsState state, CommentsFetchForTranslationResultAction action) =>
            new CommentsState(
                isLoading: state.IsLoading,
                searchPageNr: state.SearchPageNr,
                itemsPerPage: state.ItemsPerPage,
                commentId: state.CommentId,
                translationId: state.TranslationId,
                token: state.Token,
                statusCode: state.StatusCode,
                comment: state.Comment,
                rootObject: action.RootObject,
                deleteResponse: state.DeleteResponse,
                lastActionState: EActionState.FetchedForTranslation);



    }
}