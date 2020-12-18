﻿using OriinDic.Models;

namespace OriinDic.Store.Comments
{
    public class CommentsFetchDataResultAction
    {
        public RootObject<Comment> RootObject { get; init; } = new RootObject<Comment>();

        public CommentsFetchDataResultAction(RootObject<Comment> rootObject)
        {
            RootObject = rootObject;
        }
    }
}