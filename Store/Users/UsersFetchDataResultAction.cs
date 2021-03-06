﻿using System.Net;
using OriinDic.Models;

namespace OriinDic.Store.Users
{
    public record UsersFetchDataResultAction
    {
        public RootObject<User> RootObject { get; } = new();
        public HttpStatusCode ResultCode { get; } = HttpStatusCode.BadRequest;
        public UsersFetchDataResultAction(RootObject<User> rootObject, HttpStatusCode resultCode)
        {
            RootObject = rootObject;
            ResultCode = resultCode;
        }
    }
}
