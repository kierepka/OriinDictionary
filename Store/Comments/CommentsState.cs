using OriinDic.Models;

namespace OriinDic.Store.Comments
{
    public class CommentsState
    {
        public EActionState LastActionState { get; }
        public DeletedObjectResponse? DeleteResponse { get; }
        public long TranslationId { get; }
        public long CommentId { get; }
        public Comment Comment { get; }
        public string StatusCode { get; }
        public string Token { get; }
        public int SearchPageNr { get; }
        public long ItemsPerPage { get; }
        public bool IsLoading { get; }
        public RootObject<Comment> RootObject { get; }



        public CommentsState(bool isLoading, int searchPageNr, long itemsPerPage, long commentId, long translationId,
            string token, string statusCode, Comment comment, RootObject<Comment> rootObject,
            DeletedObjectResponse? deleteResponse)
        {
            LastActionState = EActionState.Initializing;
            IsLoading = isLoading;
            SearchPageNr = searchPageNr;
            ItemsPerPage = itemsPerPage;
            CommentId = commentId;
            TranslationId = translationId;
            Token = token;
            StatusCode = statusCode;
            Comment = comment;
            RootObject = rootObject;
            DeleteResponse = deleteResponse;
            LastActionState = EActionState.Initialized;
        }
        public CommentsState(Comment comment, EActionState lastActionState)
        {
            IsLoading = true;
            Comment = comment;
            LastActionState = lastActionState;
        }

        public CommentsState(long commentId, EActionState lastActionState)
        {
            IsLoading = true;
            CommentId = commentId;
            LastActionState = lastActionState;
        }

        public CommentsState(Comment comment, string statusCode, EActionState lastActionState)
        {
            IsLoading = false;
            Comment = comment;
            StatusCode = statusCode;
            LastActionState = lastActionState;
        }

        public CommentsState(long translationId, string token, EActionState lastActionState)
        {
            IsLoading = true;
            TranslationId = translationId;
            Token = token;
            LastActionState = lastActionState;
        }


        public CommentsState(string token, int searchPageNr, long itemsPerPage, EActionState lastActionState)
        {
            IsLoading = true;
            Token = token;
            SearchPageNr = searchPageNr;
            ItemsPerPage = itemsPerPage;
            LastActionState = lastActionState;
        }


        public CommentsState(DeletedObjectResponse delteResponse, EActionState lastActionState)
        {
            IsLoading = false;
            DeleteResponse = delteResponse;
            LastActionState = lastActionState;
        }

        public CommentsState(RootObject<Comment> fetchResponse, EActionState lastActionState)
        {
            IsLoading = false;
            RootObject = fetchResponse;
            LastActionState = lastActionState;
        }
    }
}