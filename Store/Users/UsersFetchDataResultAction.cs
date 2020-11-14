using OriinDic.Models;

namespace OriinDic.Store.Users
{
    public class UsersFetchDataResultAction
    {
        public RootObject<User> RootObject { get; init; } = new RootObject<User>();

        public UsersFetchDataResultAction(RootObject<User> rootObject)
        {
            RootObject = rootObject;
        }
    }
}
