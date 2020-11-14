using OriinDic.Models;

namespace OriinDic.Store.Users
{
    public class UsersState
    {
        public EActionState LastActionState { get; init; } = EActionState.Initializing;
        public UserAdd UserAdd { get; init; } = new UserAdd();
        public DeletedObjectResponse DeleteResponse { get; init; } = new DeletedObjectResponse();
        public UserUpdate UserUpdate { get; init; } = new UserUpdate();
        public RootObject<User> RootObject { get; init; } = new RootObject<User>();
        public User User { get; init; } = new User();
        public string StatusCode { get; init; } = string.Empty;
        public string Token { get; init; } = string.Empty;
        public long UserId { get; init; } = 0;        
        public int SearchPageNr { get; init; } = 0;
        public long ItemsPerPage { get; init; } = 0;
        public bool IsLoading { get; init; } = false;
        

        public UsersState(
            bool isLoading,
            long itemsPerPage,
            int searchPageNr,             
            long userId, 
            string token, 
            string statusCode,
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
}