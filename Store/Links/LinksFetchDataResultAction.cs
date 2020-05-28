using OriinDic.Models;

namespace OriinDic.Store.Links
{
    public class LinksFetchDataResultAction
    {
        public RootObject<OriinLink> RootObject { get; }

        public LinksFetchDataResultAction(RootObject<OriinLink> rootObject)
        {
            RootObject = rootObject;
        }
    }
}
