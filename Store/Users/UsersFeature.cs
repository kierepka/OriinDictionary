﻿using System.Net;
using Fluxor;

namespace OriinDic.Store.Users
{
    public class UsersFeature: Feature<UsersState>
    {
        public override string GetName() => "Users";


        protected override UsersState GetInitialState() => new(
            isLoading: false,
            itemsPerPage: 0,
            searchPageNr: 0,
            userId: 0, 
            token: string.Empty,
            statusCode: HttpStatusCode.OK,
            user: new Models.User(),
            rootObject: new Models.RootObject<Models.User>(),
            userUpdate: new Models.UserUpdate(),
            deleteResponse: new Models.DeletedObjectResponse(),
            userAdd: new Models.UserAdd(),
            lastActionState: EActionState.Initializing);
    }
}