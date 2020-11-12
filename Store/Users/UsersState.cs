using OriinDic.Models;

namespace OriinDic.Store.Users
{
    public class UsersState
    {
        public EActionState LastActionState { get; init; }
        public UserAdd UserAdd { get; init; } = new UserAdd();
        public DeletedObjectResponse DeleteResponse { get; init; } = new DeletedObjectResponse();
        public long UserId { get; init; } = long.MinValue;
        public User User { get; init; } = new User();
        public string StatusCode { get; init; } = string.Empty;

        public UserUpdate UserUpdate { get; init; } = new UserUpdate();
        public string Token { get; init; } = string.Empty;
        public int SearchPageNr { get; init; } = int.MinValue;
        public long ItemsPerPage { get; init; } = long.MinValue;
        public bool IsLoading { get; init; } = false;
        public RootObject<User> RootObject { get; init; } = new RootObject<User>();


        public UsersState(bool isLoading, int searchPageNr, long itemsPerPage, long userId, string token, string statusCode,
            User user, UserAdd userAdd, UserUpdate userUpdate, RootObject<User> rootObject, DeletedObjectResponse deleteResponse)
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
            LastActionState = EActionState.Initialized;
        }

        public UsersState(string token, int searchPageNr, long itemsPerPage, EActionState lastActionState)
        {
            IsLoading = true;
            Token = token;
            SearchPageNr = searchPageNr;
            ItemsPerPage = itemsPerPage;
            LastActionState = lastActionState;
        }



        public UsersState(UserAdd userAdd, string token, EActionState lastActionState)
        {
            IsLoading = true;
            UserAdd = userAdd;
            Token = token;
            LastActionState = lastActionState;
        }


        public UsersState(long userId, EActionState lastActionState)
        {
            IsLoading = true;
            UserId = userId;
            LastActionState = lastActionState;
        }

        public UsersState(long userId, string token, EActionState lastActionState)
        {
            IsLoading = true;
            UserId = userId;
            Token = token;
            LastActionState = lastActionState;
        }

        public UsersState(long userId, UserUpdate userUpdate, string token, EActionState lastActionState)
        {
            IsLoading = true;
            UserId = userId;
            UserUpdate = userUpdate;
            Token = token;
            LastActionState = lastActionState;
        }

        public UsersState(User user, string statusCode, EActionState lastActionState)
        {
            User = user;
            StatusCode = statusCode;
            LastActionState = lastActionState;
            IsLoading = false;
        }

        public UsersState(DeletedObjectResponse deleteResponse, EActionState lastActionState)
        {
            DeleteResponse = deleteResponse;
            LastActionState = lastActionState;
            IsLoading = false;
        }

        public UsersState(RootObject<User> rootObject, EActionState lastActionState)
        {
            LastActionState = lastActionState;
            RootObject = rootObject ?? new RootObject<User>();
            IsLoading = false;
        }

        public UsersState(User user, EActionState lastActionState)
        {
            User = user;
            LastActionState = lastActionState;
            IsLoading = false;
        }
    }
}