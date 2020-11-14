using OriinDic.Models;

namespace OriinDic.Store.Links
{
    public class LinksFetchDataResultAction
    {
        public RootObject<OriinLink> RootObject { get; init; } = new RootObject<OriinLink>();

        public LinksFetchDataResultAction(RootObject<OriinLink> rootObject)
        {
            RootObject = rootObject;
        }
    }
}
