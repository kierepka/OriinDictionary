using OriinDic.Models;

namespace OriinDic.Store.BaseTerms
{
    public class BaseTermsAddAction
    {
        public string Token { get; }
        public BaseTerm BaseTerm { get; }

        public BaseTermsAddAction(BaseTerm baseTerm, string token)
        {
            Token = token;
            BaseTerm = baseTerm;
        }
    }
}