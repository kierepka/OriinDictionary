using OriinDic.Models;

namespace OriinDic.Store.Comments
{
    public class CommentsState
    {
        public EActionState LastActionState { get; init; } = EActionState.Initializing;
        public DeletedObjectResponse DeleteResponse { get; init; } = new DeletedObjectResponse();
        public Comment Comment { get; init; } = new Comment();
        public RootObject<Comment> RootObject { get; init; } = new RootObject<Comment>();
        public long TranslationId { get; init; } = 0;
        public long CommentId { get; init; } = 0;
        public string StatusCode { get; init; } = string.Empty;
        public string Token { get; init; } = string.Empty;
        public int SearchPageNr { get; init; } = 0;
        public long ItemsPerPage { get; init; } = 0;
        public bool IsLoading { get; init; } = false;
        



        public CommentsState(
            bool isLoading, 
            int searchPageNr, 
            long itemsPerPage, 
            long commentId, 
            long translationId,
            string token, 
            string statusCode, 
            Comment comment, 
            RootObject<Comment> rootObject,
            DeletedObjectResponse deleteResponse,
            EActionState lastActionState
            )
        {
           
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
            LastActionState = lastActionState;
        }
      
    }
}