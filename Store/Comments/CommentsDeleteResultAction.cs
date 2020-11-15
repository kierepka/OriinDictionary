using OriinDic.Models;

namespace OriinDic.Store.Comments
{
    public class CommentsDeleteResultAction
    {
        public DeletedObjectResponse DeleteResponse { get; init; } = new DeletedObjectResponse();
        public RootObject<Comment> RootObject { get; init; } = new RootObject<Comment>();
        public CommentsDeleteResultAction(DeletedObjectResponse deleteResponse, RootObject<Comment> rootObject)
        {
            DeleteResponse = deleteResponse;
            RootObject = rootObject;
        }
    }
}
