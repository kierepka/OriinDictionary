using OriinDic.Models;

namespace OriinDic.Store.Comments
{
    public class CommentsState
    {
        public EActionState LastActionState { get; private set; }
        public DeletedObjectResponse DeleteResponse { get; private set; } 
        public long TranslationId { get; private set; } 
        public long CommentId { get; private set; } 
        public Comment Comment { get; private set; } 
        public string StatusCode { get; private set; } 
        public string Token { get; private set; } 
        public int SearchPageNr { get; private set; } 
        public long ItemsPerPage { get; private set; } 
        public bool IsLoading { get; private set; } 
        public RootObject<Comment> RootObject { get; private set; } 



        public CommentsState(bool isLoading, int searchPageNr, long itemsPerPage, long commentId, long translationId,
            string token, string statusCode, Comment comment, RootObject<Comment> rootObject,
            DeletedObjectResponse deleteResponse)
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


            DeleteResponse = new DeletedObjectResponse();
            TranslationId = long.MinValue;
            CommentId = long.MinValue;
            StatusCode = string.Empty;
            Token = string.Empty;
            SearchPageNr = int.MinValue;
            ItemsPerPage = long.MinValue;
            RootObject = new RootObject<Comment>();

        }

        public CommentsState(long commentId, EActionState lastActionState)
        {
            IsLoading = true;
            CommentId = commentId;
            LastActionState = lastActionState;

            DeleteResponse = new DeletedObjectResponse();
            TranslationId = long.MinValue;
            Comment = new Comment();
            StatusCode = string.Empty;
            Token = string.Empty;
            SearchPageNr = int.MinValue;
            ItemsPerPage = long.MinValue;
            RootObject = new RootObject<Comment>();
        }

        public CommentsState(Comment comment, string statusCode, EActionState lastActionState)
        {
            IsLoading = false;
            Comment = comment;
            StatusCode = statusCode;
            LastActionState = lastActionState;

            DeleteResponse = new DeletedObjectResponse();
            TranslationId = long.MinValue;
            CommentId = long.MinValue;
            Token = string.Empty;
            SearchPageNr = int.MinValue;
            ItemsPerPage = long.MinValue;
            RootObject = new RootObject<Comment>();
        }

        public CommentsState(long translationId, string token, EActionState lastActionState)
        {
            IsLoading = true;
            TranslationId = translationId;
            Token = token;
            LastActionState = lastActionState;

            DeleteResponse = new DeletedObjectResponse();
            CommentId = long.MinValue;
            Comment = new Comment();
            StatusCode = string.Empty;
            SearchPageNr = int.MinValue;
            ItemsPerPage = long.MinValue;
            RootObject = new RootObject<Comment>();
        }


        public CommentsState(string token, int searchPageNr, long itemsPerPage, EActionState lastActionState)
        {
            IsLoading = true;
            Token = token;
            SearchPageNr = searchPageNr;
            ItemsPerPage = itemsPerPage;
            LastActionState = lastActionState;

            DeleteResponse = new DeletedObjectResponse();
            TranslationId = long.MinValue;
            CommentId = long.MinValue;
            Comment = new Comment();
            StatusCode = string.Empty;
            RootObject = new RootObject<Comment>();
        }


        public CommentsState(DeletedObjectResponse delteResponse, EActionState lastActionState)
        {
            IsLoading = false;
            DeleteResponse = delteResponse;
            LastActionState = lastActionState;

            TranslationId = long.MinValue;
            CommentId = long.MinValue;
            Comment = new Comment();
            StatusCode = string.Empty;
            Token = string.Empty;
            SearchPageNr = int.MinValue;
            ItemsPerPage = long.MinValue;
            RootObject = new RootObject<Comment>();

        }

        public CommentsState(RootObject<Comment> fetchResponse, EActionState lastActionState)
        {
            IsLoading = false;
            RootObject = fetchResponse;
            LastActionState = lastActionState;

            DeleteResponse = new DeletedObjectResponse();
            TranslationId = long.MinValue;
            CommentId = long.MinValue;
            Comment = new Comment();
            StatusCode = string.Empty;
            Token = string.Empty;
            SearchPageNr = int.MinValue;
            ItemsPerPage = long.MinValue;
        }
    }
}