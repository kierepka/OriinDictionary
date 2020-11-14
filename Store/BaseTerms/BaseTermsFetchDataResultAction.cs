using OriinDic.Models;

namespace OriinDic.Store.BaseTerms
{
    public class BaseTermsFetchDataResultAction
    {
        public RootObject<ResultBaseTranslation> RootObject { get; init; } = new RootObject<ResultBaseTranslation>();

        public BaseTermsFetchDataResultAction(RootObject<ResultBaseTranslation> rootObject)
        {
            RootObject = rootObject;
        }
    }
}
