using OriinDic.Models;

namespace OriinDic.Store.BaseTerms
{
    public class BaseTermsUpdateResultAction
    {
        public BaseTerm BaseTerm { get; }

        public BaseTermsUpdateResultAction(BaseTerm baseTerm)
        {
            BaseTerm = baseTerm;
        }
    }
}
