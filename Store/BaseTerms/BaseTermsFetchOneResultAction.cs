using OriinDictionary7.Models;

using System.Net;

namespace OriinDictionary7.Store.BaseTerms;

public record BaseTermsFetchOneResultAction
{
    public ResultBaseTranslation BaseTranslation { get; } = new();
    public List<OriinLink> Links { get; } = new();
    public HttpStatusCode HttpStatusCode { get; }

    public BaseTermsFetchOneResultAction(ResultBaseTranslation baseTranslation, List<OriinLink> links,
        HttpStatusCode httpStatusCode)
    {
        BaseTranslation = baseTranslation;
        Links = links;
        HttpStatusCode = httpStatusCode;
    }
}
