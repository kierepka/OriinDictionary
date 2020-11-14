namespace OriinDic.Store.Users
{
    public class UsersDeleteAction
    {
        public string Token { get; init; } = string.Empty;
        public long UserId { get; init; } = 0;

        public UsersDeleteAction(long userId, string token)
        {
            Token = token;
            UserId = userId;
        }
    }
}