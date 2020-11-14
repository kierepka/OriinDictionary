using OriinDic.Models;

namespace OriinDic.Store.Search
{
    public class SearchTranslationsResultAction
    {
        public RootObject<ResultBaseTranslation> RootObject { get; init; } = new RootObject<ResultBaseTranslation>();

        public SearchTranslationsResultAction(RootObject<ResultBaseTranslation> rootObject)
        {
            RootObject = rootObject;
        }
    }
}