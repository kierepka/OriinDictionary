using OriinDic.Models;

namespace OriinDic.Store.BaseTerms
{
    public class BaseTermsUpdateAction
    {
        public long BaseTermId { get; init; } = 0;
        public string Token { get; init; } = string.Empty;
        public BaseTerm BaseTerm { get; init; } = new BaseTerm();

        public BaseTermsUpdateAction(long baseTermId, BaseTerm baseTerm, string token)
        {
            BaseTermId = baseTermId;
            Token = token;
            BaseTerm = baseTerm;
        }
    }
}