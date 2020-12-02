using OriinDic.Models;

namespace OriinDic.Store.Links
{
    public class LinksDeleteResultAction
    {
        public DeletedObjectResponse DelteResponse { get; init; } = new DeletedObjectResponse();

        public RootObject<OriinLink> RootObject { get; init; } = new RootObject<OriinLink>();

        public LinksDeleteResultAction(DeletedObjectResponse delteResponse, RootObject<OriinLink> rootObject)
        {
            DelteResponse = delteResponse;
            RootObject = rootObject;
        }
    }
}
