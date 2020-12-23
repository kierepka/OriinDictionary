using OriinDic.Models;

namespace OriinDic.Store.Users
{
    public record UsersAddAction
    {
        public string Token { get; } = string.Empty;
        public UserAdd User { get; } = new();
        public string UserAddedMessage { get; } = string.Empty;
        public UsersAddAction(UserAdd user, string token, string userAddedMessage)
        {
            Token = token;
            UserAddedMessage = userAddedMessage;
            User = user;
        }
    }
}