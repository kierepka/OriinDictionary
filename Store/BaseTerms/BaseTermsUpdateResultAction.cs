using OriinDic.Models;

namespace OriinDic.Store.BaseTerms
{
    public class BaseTermsUpdateResultAction
    {
        public BaseTerm BaseTerm { get; init; }

        public BaseTermsUpdateResultAction(BaseTerm baseTerm)
        {
            BaseTerm = baseTerm;
        }
    }
}
