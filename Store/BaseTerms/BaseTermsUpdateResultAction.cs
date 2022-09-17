using OriinDictionary7.Models;

using System.Net;

namespace OriinDictionary7.Store.BaseTerms;

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
