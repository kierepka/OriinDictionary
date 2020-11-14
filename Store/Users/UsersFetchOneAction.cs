namespace OriinDic.Store.Users
{
    public class UsersFetchOneAction
    {
        public long UserId { get; init; } = 0;
        public string Token { get; init; } = string.Empty;


        public UsersFetchOneAction(long userId, string token)
        {
            UserId = userId;
            Token = token;
        }
    }
}