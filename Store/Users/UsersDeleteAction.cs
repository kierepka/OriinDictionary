namespace OriinDic.Store.Users
{
    public class UsersDeleteAction
    {
        public string Token { get; }
        public long UserId { get; }

        public UsersDeleteAction(long userId, string token)
        {
            Token = token;
            UserId = userId;
        }
    }
}