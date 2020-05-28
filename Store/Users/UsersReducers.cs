using Fluxor;

namespace OriinDic.Store.Users
{
    public static class UsersReducers
    {

        [ReducerMethod]
        public static UsersState ReduceAddAction(UsersState state, UsersAddAction action) =>
            new UsersState(userAdd: action.User, token: action.Token, lastActionState: EActionState.Adding);

        [ReducerMethod]
        public static UsersState ReduceAddResultAction(UsersState state, UsersAddResultAction action) =>
            new UsersState(user: action.User, statusCode: action.StatusCode, lastActionState: EActionState.Added);

        [ReducerMethod]
        public static UsersState ReduceAnonymizeAction(UsersState state, UsersAnonymizeAction action) =>
            new UsersState(user: action.User, EActionState.Anonymizing);

        [ReducerMethod]
        public static UsersState ReduceAnonymizeResultAction(UsersState state, UsersAnonymizeResultAction action) =>
            new UsersState(user: action.User, statusCode: action.StatusCode, lastActionState: EActionState.Anonymized);

        [ReducerMethod]
        public static UsersState ReduceDeleteAction(UsersState state, UsersDeleteAction action) =>
            new UsersState(userId: action.UserId, lastActionState: EActionState.Deleting);

        [ReducerMethod]
        public static UsersState ReduceDeleteResultAction(UsersState state, UsersDeleteResultAction action) =>
            new UsersState(deleteResponse: action.DeleteResponse, lastActionState: EActionState.Deleted );

        [ReducerMethod]
        public static UsersState ReduceFetchOneAction(UsersState state, UsersFetchOneAction action) =>
            new UsersState(userId: action.UserId, token: action.Token, lastActionState: EActionState.FetchingOne);

        [ReducerMethod]
        public static UsersState ReduceFetchOneResultAction(UsersState state, UsersFetchOneResultAction action) =>
            new UsersState(user: action.User, lastActionState: EActionState.FetchedOne);

        [ReducerMethod]
        public static UsersState ReduceFetchDataAction(UsersState state, UsersFetchDataAction action) =>
            new UsersState(
                token: action.Token,
                searchPageNr: action.SearchPageNr,
                itemsPerPage: action.ItemsPerPage,
                lastActionState: EActionState.FetchingData
            );

        [ReducerMethod]
        public static UsersState ReduceFetchDataResultAction(UsersState state, UsersFetchDataResultAction action) =>
            new UsersState(rootObject: action.RootObject, lastActionState: EActionState.FetchedData);

        [ReducerMethod]
        public static UsersState ReduceUpdateAction(UsersState state, UsersUpdateAction action) =>
            new UsersState(userId: action.UserId, userUpdate: action.User, token: action.Token, lastActionState: EActionState.Updating);

        [ReducerMethod]
        public static UsersState ReduceUpdateResultAction(UsersState state, UsersUpdateResultAction action) =>
            new UsersState(user: action.User, lastActionState: EActionState.Updated);
    }
}