using OriinDictionary7.Models;

using System.Net;

namespace OriinDictionary7.Store.Links;

public record LinksFetchDataResultAction
{
    public RootObject<OriinLink> RootObject { get; } = new();
    public HttpStatusCode HttpStatusCode { get; }

    public LinksFetchDataResultAction(RootObject<OriinLink> rootObject, HttpStatusCode httpStatusCode)
    {
        RootObject = rootObject;
        HttpStatusCode = httpStatusCode;
    }
}
