using System.Net;
using OriinDic.Models;

namespace OriinDic.Store.BaseTerms
{
    public record BaseTermsAddResultAction
    {
        public BaseTerm BaseTerm { get; } = new();
        public HttpStatusCode HttpStatusCode { get; } = HttpStatusCode.BadRequest;
        
        public BaseTermsAddResultAction(BaseTerm baseTerm, HttpStatusCode httpStatusCode)
        {
            BaseTerm = baseTerm;
            HttpStatusCode = httpStatusCode;
        }
    }
}
