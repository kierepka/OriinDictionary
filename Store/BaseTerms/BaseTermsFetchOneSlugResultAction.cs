using OriinDictionary7.Models;

using System.Net;

namespace OriinDictionary7.Store.BaseTerms;

public record BaseTermsFetchOneSlugResultAction
{
    public BaseTerm BaseTerm { get; } = new();

    public List<OriinLink> Links { get; } = new();
    public HttpStatusCode HttpStatusCode { get; }

    public BaseTermsFetchOneSlugResultAction(BaseTerm baseTerm, List<OriinLink> links,
        HttpStatusCode httpStatusCode)
    {
        BaseTerm = baseTerm;
        Links = links;
        HttpStatusCode = httpStatusCode;
    }
}
