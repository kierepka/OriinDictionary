using OriinDic.Models;

namespace OriinDic.Store.Links
{
    public class LinksDeleteResultAction
    {
        public DeletedObjectResponse DelteResponse { get; init; } = new DeletedObjectResponse();

        public LinksDeleteResultAction(DeletedObjectResponse delteResponse)
        {
            DelteResponse = delteResponse;
        }
    }
}
