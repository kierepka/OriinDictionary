using OriinDic.Models;

namespace OriinDic.Store.BaseTerms
{
    public class BaseTermsAddResultAction
    {
        public BaseTerm BaseTerm { get; init; } = new BaseTerm();

        public BaseTermsAddResultAction(BaseTerm baseTerm)
        {
            BaseTerm = baseTerm;
        }
    }
}
