using OriinDictionary7.Models;

using System.Net;

namespace OriinDictionary7.Store.BaseTerms;

public record BaseTermsFetchDataResultAction
{
    public RootObject<ResultBaseTranslation> RootObject { get; } = new();
    public HttpStatusCode HttpStatusCode { get; }

    public BaseTermsFetchDataResultAction(RootObject<ResultBaseTranslation> rootObject,
        HttpStatusCode httpStatusCode)
    {
        RootObject = rootObject;
        HttpStatusCode = httpStatusCode;
    }
}
