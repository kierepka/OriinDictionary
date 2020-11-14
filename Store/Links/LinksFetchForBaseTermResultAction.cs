using OriinDic.Models;

namespace OriinDic.Store.Links
{
    public class LinksFetchForBaseTermResultAction
    {
        public RootObject<OriinLink> RootObject { get; init; } = new RootObject<OriinLink>();

        public LinksFetchForBaseTermResultAction(RootObject<OriinLink> rootObject)
        {
            RootObject = rootObject;
        }
    }
}
