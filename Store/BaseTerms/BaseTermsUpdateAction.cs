using OriinDic.Models;

namespace OriinDic.Store.BaseTerms
{
    public record BaseTermsUpdateAction
    {
        public long BaseTermId { get; }
        public string Token { get; } = string.Empty;
        public BaseTerm BaseTerm { get; } = new();

        public BaseTermsUpdateAction(long baseTermId, BaseTerm baseTerm, string token)
        {
            BaseTermId = baseTermId;
            Token = token;
            BaseTerm = baseTerm;
        }
    }
}