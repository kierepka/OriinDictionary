using OriinDictionary7.Models;

using System.Net;

namespace OriinDictionary7.Store.Users;

public record UsersState
{
    public EActionState LastActionState { get; } = EActionState.Initializing;
    public UserAdd UserAdd { get; } = new();
    public DeletedObjectResponse DeleteResponse { get; } = new();
    public UserUpdate UserUpdate { get; } = new();
    public RootObject<User> RootObject { get; } = new();
    public User User { get; } = new();
    public HttpStatusCode StatusCode { get; } = HttpStatusCode.OK;
    public string Token { get; } = string.Empty;
    public long UserId { get; }
    public int SearchPageNr { get; }
    public long ItemsPerPage { get; }
    public bool IsLoading { get; }


    public UsersState(
        bool isLoading,
        long itemsPerPage,
        int searchPageNr,
        long userId,
        string token,
        HttpStatusCode statusCode,
        User user,
        RootObject<User> rootObject,
        UserUpdate userUpdate,
        DeletedObjectResponse deleteResponse,
        UserAdd userAdd,
        EActionState lastActionState)
    {
        LastActionState = EActionState.Initializing;
        IsLoading = isLoading;
        SearchPageNr = searchPageNr;
        ItemsPerPage = itemsPerPage;
        UserId = userId;
        Token = token;
        StatusCode = statusCode;
        User = user;
        UserAdd = userAdd;
        UserUpdate = userUpdate;
        RootObject = rootObject;
        DeleteResponse = deleteResponse;
        LastActionState = lastActionState;
    }


}