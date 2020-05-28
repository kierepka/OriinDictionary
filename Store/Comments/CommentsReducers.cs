using Fluxor;

namespace OriinDic.Store.Comments
{
    public static class CommentsReducers
    {

        [ReducerMethod]
        public static CommentsState ReduceAddAction(CommentsState state, CommentsAddAction action) =>
            new CommentsState(comment: action.Comment, lastActionState: EActionState.Adding);
        
        [ReducerMethod]
        public static CommentsState ReduceAddResultAction(CommentsState state, CommentsAddResultAction action) =>
            new CommentsState(comment: action.Comment, statusCode: action.StatusCode, lastActionState: EActionState.Added);

        [ReducerMethod]
        public static CommentsState ReduceDeleteAction(CommentsState state, CommentsDeleteAction action) =>
            new CommentsState(commentId: action.CommentId, lastActionState: EActionState.Deleting);
        
        [ReducerMethod]
        public static CommentsState ReduceDeleteResultAction(CommentsState state, CommentsDeleteResultAction action) =>
            new CommentsState(delteResponse: action.DeleteResponse, lastActionState: EActionState.Deleted);

        [ReducerMethod]
        public static CommentsState ReduceFetchDataAction(CommentsState state, CommentsFetchDataAction action) =>
            new CommentsState(
                token: action.Token,
                searchPageNr: action.SearchPageNr,
                itemsPerPage: action.ItemsPerPage, 
                lastActionState: EActionState.FetchingData
                );

        [ReducerMethod]
        public static CommentsState ReduceFetchDataResultAction(CommentsState state, CommentsFetchDataResultAction action) =>
            new CommentsState(fetchResponse: action.RootObject,
                lastActionState: EActionState.FetchedData);

        [ReducerMethod]
        public static CommentsState ReduceFetchForTranslationAction(CommentsState state, CommentsFetchForTranslationAction action) =>
            new CommentsState(translationId: action.TranslationId, token: action.Token,
                lastActionState: EActionState.FetchingForTranslation);

        [ReducerMethod]
        public static CommentsState ReduceFetchOneAction(CommentsState state, CommentsFetchForTranslationResultAction action) =>
            new CommentsState(fetchResponse: action.RootObject,
                lastActionState: EActionState.FetchedForTranslation);

    }
}