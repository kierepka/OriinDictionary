using OriinDic.Models;

namespace OriinDic.Store.Search
{
    public class SearchTranslationsResultAction
    {
        public RootObject<ResultBaseTranslation> RootObject { get; }

        public SearchTranslationsResultAction(RootObject<ResultBaseTranslation> rootObject)
        {
            RootObject = rootObject;
        }
    }
}