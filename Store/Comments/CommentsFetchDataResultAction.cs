﻿using OriinDic.Models;

using System.Net;

namespace OriinDic.Store.Comments
{
    public class CommentsFetchDataResultAction
    {
        public RootObject<Comment> RootObject { get; } = new();
        public HttpStatusCode HttpStatusCode { get; }

        public CommentsFetchDataResultAction(RootObject<Comment> rootObject, HttpStatusCode httpStatusCode)
        {
            RootObject = rootObject;
            HttpStatusCode = httpStatusCode;
        }
    }
}
