using OriinDic.Models;

namespace OriinDic.Store.BaseTerms
{
    public class BaseTermsFetchOneSlugResultAction
    {
        public BaseTerm BaseTerm { get; init; }

        public BaseTermsFetchOneSlugResultAction(BaseTerm baseTerm)
        {
            BaseTerm = baseTerm;
        }
    }
}
