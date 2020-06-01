using OriinDic.Models;

namespace OriinDic.Store.Search
{
    public class SearchBaseTermsResultAction
    {
        public RootObject<ResultBaseTranslation> RootObject { get; }

        public SearchBaseTermsResultAction(RootObject<ResultBaseTranslation> rootObject)
        {
            RootObject = rootObject;
        }
    }
}
