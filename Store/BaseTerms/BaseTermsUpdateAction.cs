using OriinDic.Models;

namespace OriinDic.Store.BaseTerms
{
    public class BaseTermsUpdateAction
    {
        public long BaseTermId { get; }
        public string Token { get; }
        public BaseTerm BaseTerm { get; }

        public BaseTermsUpdateAction(long baseTermId, BaseTerm baseTerm, string token)
        {
            BaseTermId = baseTermId;
            Token = token;
            BaseTerm = baseTerm;
        }
    }
}