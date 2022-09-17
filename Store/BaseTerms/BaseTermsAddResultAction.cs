using OriinDictionary7.Models;

using System.Net;

namespace OriinDictionary7.Store.BaseTerms;

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
