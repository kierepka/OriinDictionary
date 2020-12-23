namespace OriinDic.Store.Users
{
    public record UsersFetchOneAction
    {
        public long UserId { get; init; }
        public string Token { get; init; } = string.Empty;

        public string UserFetchedMessage { get; } = string.Empty;
        public UsersFetchOneAction(long userId, string token, string userFetchedMessage)
        {
            UserId = userId;
            Token = token;
            UserFetchedMessage = userFetchedMessage;
        }
    }
}