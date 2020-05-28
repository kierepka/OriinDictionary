using OriinDic.Models;

namespace OriinDic.Store.BaseTerms
{
    public class BaseTermsAddResultAction
    {
        public BaseTerm BaseTerm { get; }

        public BaseTermsAddResultAction(BaseTerm baseTerm)
        {
            BaseTerm = baseTerm;
        }
    }
}
