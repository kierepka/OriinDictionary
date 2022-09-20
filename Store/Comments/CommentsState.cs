using OriinDictionary7.Models;

namespace OriinDictionary7.Store.Comments;

public record CommentsState
{
    public EActionState LastActionState { get; } = EActionState.Initializing;
    public DeletedObjectResponse DeleteResponse { get; } = new();
    public Comment Comment { get; } = new();
    public RootObject<Comment> RootObject { get; } = new();
    public long TranslationId { get; }
    public long CommentId { get; }
    public string StatusCode { get; } = string.Empty;
    public string Token { get; } = string.Empty;
    public int SearchPageNr { get; }
    public long ItemsPerPage { get; }
    public bool IsLoading { get; }

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