using OriinDic.Models;

namespace OriinDic.Store.BaseTerms
{
    public class BaseTermsUpdateAction
    {
        public long BaseTermId { get; init; }
        public string Token { get; init; }
        public BaseTerm BaseTerm { get; init; }

        public BaseTermsUpdateAction(long baseTermId, BaseTerm baseTerm, string token)
        {
            BaseTermId = baseTermId;
            Token = token;
            BaseTerm = baseTerm;
        }
    }
}