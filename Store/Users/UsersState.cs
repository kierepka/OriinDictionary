﻿using OriinDic.Models;

namespace OriinDic.Store.Users
{
    public class UsersState
    {
        public EActionState LastActionState { get; private set; }
        public UserAdd UserAdd { get; private set; }
        public DeletedObjectResponse? DeleteResponse { get; private set; }
        public long UserId { get; private set; }
        public User? User { get; private set; }
        public string StatusCode { get; private set; }

        public UserUpdate? UserUpdate { get; private set; }
        public string Token { get; private set; }
        public int SearchPageNr { get; private set; }
        public long ItemsPerPage { get; private set; }
        public bool IsLoading { get; private set; }
        public RootObject<User>? RootObject { get; private set; }


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