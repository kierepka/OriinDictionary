using Fluxor;

namespace OriinDic.Store.Users
{
    public class UsersFeature: Feature<UsersState>
    {
        public override string GetName() => "Users";

        
        protected override UsersState GetInitialState() => new UsersState(isLoading: false, searchPageNr: 0,
            itemsPerPage: 0, userId: 0, token: string.Empty, statusCode: string.Empty, user: null, userAdd: null,
            userUpdate: null, rootObject: null, deleteResponse: null);
    }
}