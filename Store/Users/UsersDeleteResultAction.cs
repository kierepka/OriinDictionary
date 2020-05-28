using OriinDic.Models;

namespace OriinDic.Store.Users
{
    public class UsersDeleteResultAction
    {
        public DeletedObjectResponse DeleteResponse { get; }

        public UsersDeleteResultAction(DeletedObjectResponse deleteResponse)
        {
            DeleteResponse = deleteResponse;
        }
    }
}
