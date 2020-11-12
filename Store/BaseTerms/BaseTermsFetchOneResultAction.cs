using OriinDic.Models;

namespace OriinDic.Store.BaseTerms
{
    public class BaseTermsFetchOneResultAction
    {
        public ResultBaseTranslation? BaseTranslation { get; init; }

        public BaseTermsFetchOneResultAction(ResultBaseTranslation? baseTranslation)
        {
            BaseTranslation = baseTranslation;
        }
    }
}
