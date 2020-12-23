﻿using OriinDic.Models;

namespace OriinDic.Store.Users
{
    public record UsersPasswordResetAction
    {
        public string Token { get; } = string.Empty;
        public UserPwdReset User { get; } = new();
        public string UserPasswordResetMessage { get; } = string.Empty;
        
        public UsersPasswordResetAction(UserPwdReset user, string token, string userPasswordResetMessage)
        {
            Token = token;
            UserPasswordResetMessage = userPasswordResetMessage;
            User = user;
        }
    }
}