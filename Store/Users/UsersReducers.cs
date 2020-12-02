using Fluxor;

namespace OriinDic.Store.Users
{
    public static class UsersReducers
    {

        [ReducerMethod]
        public static UsersState ReduceAddAction(UsersState state, UsersAddAction action) =>
            new UsersState(
                 isLoading: state.IsLoading,
                 itemsPerPage: state.ItemsPerPage,
                 searchPageNr: state.SearchPageNr,
                 userId: state.UserId,
                 token: action.Token,
                 statusCode: state.StatusCode,
                 user: state.User,
                 rootObject: state.RootObject,
                 userUpdate: state.UserUpdate,
                 deleteResponse: state.DeleteResponse,
                 userAdd: action.User,
                 lastActionState: EActionState.Adding);

        [ReducerMethod]
        public static UsersState ReduceAddResultAction(UsersState state, UsersAddResultAction action) =>
            new UsersState(
                isLoading: state.IsLoading,
                itemsPerPage: state.ItemsPerPage,
                searchPageNr: state.SearchPageNr,
                userId: state.UserId,
                token: state.Token,
                statusCode: action.StatusCode,
                user: action.User,
                rootObject: state.RootObject,
                userUpdate: state.UserUpdate,
                deleteResponse: state.DeleteResponse,
                userAdd: state.UserAdd,
                lastActionState: EActionState.Added);


        [ReducerMethod]
        public static UsersState ReduceAnonymizeAction(UsersState state, UsersAnonymizeAction action) =>
            new UsersState(
                isLoading: state.IsLoading,
                itemsPerPage: state.ItemsPerPage,
                searchPageNr: state.SearchPageNr,
                userId: state.UserId,
                token: state.Token,
                statusCode: state.StatusCode,
                user: action.User,
                rootObject: state.RootObject,
                userUpdate: state.UserUpdate,
                deleteResponse: state.DeleteResponse,
                userAdd: state.UserAdd,
                lastActionState: EActionState.Anonymization);

        [ReducerMethod]
        public static UsersState ReduceAnonymizeResultAction(UsersState state, UsersAnonymizeResultAction action) =>
            new UsersState(
                isLoading: state.IsLoading,
                itemsPerPage: state.ItemsPerPage,
                searchPageNr: state.SearchPageNr,
                userId: state.UserId,
                token: state.Token,
                statusCode: action.StatusCode,
                user: action.User,
                rootObject: state.RootObject,
                userUpdate: state.UserUpdate,
                deleteResponse: state.DeleteResponse,
                userAdd: state.UserAdd,
                lastActionState: EActionState.Anonymized);

        [ReducerMethod]
        public static UsersState ReduceDeleteAction(UsersState state, UsersDeleteAction action) =>
            new UsersState(
                isLoading: state.IsLoading,
                itemsPerPage: state.ItemsPerPage,
                searchPageNr: state.SearchPageNr,
                userId: action.UserId,
                token: state.Token,
                statusCode: state.StatusCode,
                user: state.User,
                rootObject: state.RootObject,
                userUpdate: state.UserUpdate,
                deleteResponse: state.DeleteResponse,
                userAdd: state.UserAdd,
                lastActionState: EActionState.Deleting);

        [ReducerMethod]
        public static UsersState ReduceDeleteResultAction(UsersState state, UsersDeleteResultAction action) =>
            new UsersState(
                isLoading: state.IsLoading,
                itemsPerPage: state.ItemsPerPage,
                searchPageNr: state.SearchPageNr,
                userId: state.UserId,
                token: state.Token,
                statusCode: state.StatusCode,
                user: state.User,
                rootObject: state.RootObject,
                userUpdate: state.UserUpdate,
                deleteResponse: action.DeleteResponse,
                userAdd: state.UserAdd,
                lastActionState: EActionState.Deleted);

        [ReducerMethod]
        public static UsersState ReduceFetchOneAction(UsersState state, UsersFetchOneAction action) =>
            new UsersState(
                isLoading: state.IsLoading,
                itemsPerPage: state.ItemsPerPage,
                searchPageNr: state.SearchPageNr,
                userId: action.UserId,
                token: action.Token,
                statusCode: state.StatusCode,
                user: state.User,
                rootObject: state.RootObject,
                userUpdate: state.UserUpdate,
                deleteResponse: state.DeleteResponse,
                userAdd: state.UserAdd,
                lastActionState: EActionState.FetchingOne);

        [ReducerMethod]
        public static UsersState ReduceFetchOneResultAction(UsersState state, UsersFetchOneResultAction action) =>
            new UsersState(
                isLoading: state.IsLoading,
                itemsPerPage: state.ItemsPerPage,
                searchPageNr: state.SearchPageNr,
                userId: state.UserId,
                token: state.Token,
                statusCode: state.StatusCode,
                user: action.User,
                rootObject: state.RootObject,
                userUpdate: state.UserUpdate,
                deleteResponse: state.DeleteResponse,
                userAdd: state.UserAdd,
                lastActionState: EActionState.FetchedOne);

        [ReducerMethod]
        public static UsersState ReduceFetchDataAction(UsersState state, UsersFetchDataAction action) =>
            new UsersState(
                isLoading: state.IsLoading,
                itemsPerPage: action.ItemsPerPage,
                searchPageNr: action.SearchPageNr,
                userId: state.UserId,
                token: action.Token,
                statusCode: state.StatusCode,
                user: state.User,
                rootObject: state.RootObject,
                userUpdate: state.UserUpdate,
                deleteResponse: state.DeleteResponse,
                userAdd: state.UserAdd,
                lastActionState: EActionState.FetchingData);

        [ReducerMethod]
        public static UsersState ReduceFetchDataResultAction(UsersState state, UsersFetchDataResultAction action) =>
            new UsersState(
                isLoading: state.IsLoading,
                itemsPerPage: state.ItemsPerPage,
                searchPageNr: state.SearchPageNr,
                userId: state.UserId,
                token: state.Token,
                statusCode: state.StatusCode,
                user: state.User,
                rootObject: action.RootObject,
                userUpdate: state.UserUpdate,
                deleteResponse: state.DeleteResponse,
                userAdd: state.UserAdd,
                lastActionState: EActionState.FetchedData);

        [ReducerMethod]
        public static UsersState ReduceUpdateAction(UsersState state, UsersUpdateAction action) =>
            new UsersState(
                isLoading: state.IsLoading,
                itemsPerPage: state.ItemsPerPage,
                searchPageNr: state.SearchPageNr,
                userId: action.UserId,
                token: action.Token,
                statusCode: state.StatusCode,
                user: state.User,
                rootObject: state.RootObject,
                userUpdate: action.User,
                deleteResponse: state.DeleteResponse,
                userAdd: state.UserAdd,
                lastActionState: EActionState.Updating);

        [ReducerMethod]
        public static UsersState ReduceUpdateResultAction(UsersState state, UsersUpdateResultAction action) =>
            new UsersState(
                isLoading: state.IsLoading,
                itemsPerPage: state.ItemsPerPage,
                searchPageNr: state.SearchPageNr,
                userId: state.UserId,
                token: state.Token,
                statusCode: state.StatusCode,
                user: action.User,
                rootObject: state.RootObject,
                userUpdate: state.UserUpdate,
                deleteResponse: state.DeleteResponse,
                userAdd: state.UserAdd,
                lastActionState: EActionState.Updated);

    }
}