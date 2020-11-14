using OriinDic.Models;

namespace OriinDic.Store.BaseTerms
{
    public class BaseTermsAddAction
    {
        public string Token { get; init; } = string.Empty;
        public BaseTerm BaseTerm { get; init; } = new BaseTerm();

        public BaseTermsAddAction(BaseTerm baseTerm, string token)
        {
            Token = token;
            BaseTerm = baseTerm;
        }
    }
}