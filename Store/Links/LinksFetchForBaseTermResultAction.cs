using OriinDic.Models;

namespace OriinDic.Store.Links
{
    public class LinksFetchForBaseTermResultAction
    {
        public RootObject<OriinLink> RootObject { get; }

        public LinksFetchForBaseTermResultAction(RootObject<OriinLink> rootObject)
        {
            RootObject = rootObject;
        }
    }
}
