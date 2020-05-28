namespace OriinDic.Store.Users
{
    public class UsersFetchOneAction
    {
        public long UserId { get; }
        public string Token { get; }


        public UsersFetchOneAction(long userId, string token)
        {
            UserId = userId;
            Token = token;
        }
    }
}