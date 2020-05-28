using OriinDic.Models;

namespace OriinDic.Store.Users
{
    public class UsersState
    {
        public EActionState LastActionState { get; }
        public UserAdd UserAdd { get; }
        public DeletedObjectResponse? DeleteResponse { get; }
        public long UserId { get; }
        public User? User { get; }
        public string StatusCode { get; }

        public UserUpdate? UserUpdate { get; }
        public string Token { get; }
        public int SearchPageNr { get; }
        public long ItemsPerPage { get; }
        public bool IsLoading { get; }
        public RootObject<User>? RootObject { get; }


        public UsersState(bool isLoading, int searchPageNr, long itemsPerPage, long userId, string token, string statusCode,
            User? user, UserAdd? userAdd, UserUpdate? userUpdate, RootObject<User>? rootObject, DeletedObjectResponse? deleteResponse)
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