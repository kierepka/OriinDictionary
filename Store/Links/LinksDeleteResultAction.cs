using OriinDic.Models;

namespace OriinDic.Store.Links
{
    public class LinksDeleteResultAction
    {
        public DeletedObjectResponse DelteResponse { get; }

        public LinksDeleteResultAction(DeletedObjectResponse delteResponse)
        {
            DelteResponse = delteResponse;
        }
    }
}
