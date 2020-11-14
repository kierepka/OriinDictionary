using OriinDic.Models;

namespace OriinDic.Store.Search
{
    public class SearchBaseTermsResultAction
    {
        public RootObject<ResultBaseTranslation> RootObject { get; init; } = new RootObject<ResultBaseTranslation>();

        public SearchBaseTermsResultAction(RootObject<ResultBaseTranslation> rootObject)
        {
            RootObject = rootObject;
        }
    }
}
