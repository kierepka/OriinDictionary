using System.Net;
using OriinDic.Models;

namespace OriinDic.Store.BaseTerms
{
    public record BaseTermsUpdateResultAction
    {
        public BaseTerm BaseTerm { get; } = new();
        public HttpStatusCode ResultCode { get; }

        public BaseTermsUpdateResultAction(BaseTerm baseTerm, HttpStatusCode resultCode)
        {
            BaseTerm = baseTerm;
            ResultCode = resultCode;
        }
    }
}
