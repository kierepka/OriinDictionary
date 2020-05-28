using OriinDic.Models;

namespace OriinDic.Store.BaseTerms
{
    public class BaseTermsFetchOneResultAction
    {
        public BaseTerm BaseTerm { get; }

        public BaseTermsFetchOneResultAction(BaseTerm baseTerm)
        {
            BaseTerm = baseTerm;
        }
    }
}
