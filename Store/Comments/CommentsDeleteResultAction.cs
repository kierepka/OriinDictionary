using OriinDic.Models;

namespace OriinDic.Store.Comments
{
    public class CommentsDeleteResultAction
    {
        public DeletedObjectResponse DeleteResponse { get; }

        public CommentsDeleteResultAction(DeletedObjectResponse deleteResponse)
        {
            DeleteResponse = deleteResponse;
        }
    }
}
