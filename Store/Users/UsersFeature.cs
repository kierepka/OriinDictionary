using Fluxor;

namespace OriinDic.Store.Users
{
    public class UsersFeature: Feature<UsersState>
    {
        public override string GetName() => "Users";

        
        protected override UsersState GetInitialState() => new UsersState(isLoading: false, searchPageNr: 0,
            itemsPerPage: 0, userId: 0, token: string.Empty, statusCode: string.Empty, user: new Models.User(), userAdd: new Models.UserAdd(),
            userUpdate: new Models.UserUpdate(), rootObject: new Models.RootObject<Models.User>(), deleteResponse: new Models.DeletedObjectResponse());
    }
}