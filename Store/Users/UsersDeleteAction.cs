namespace OriinDic.Store.Users
{
    public record UsersDeleteAction
    {
        public string Token { get; } = string.Empty;
        public long UserId { get; }
        public string UserDeleteMessage { get; } = string.Empty;
        public UsersDeleteAction(long userId, string token, string userDeleteMessage)
        {
            Token = token;
            UserDeleteMessage = userDeleteMessage;
            UserId = userId;
        }
    }
}