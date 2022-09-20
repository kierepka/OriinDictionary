using OriinDictionary7.Models;

using System.Net;

namespace OriinDictionary7.Store.Links;

public record LinksDeleteResultAction
{
    public DeletedObjectResponse DelteResponse { get; } = new();

    public RootObject<OriinLink> RootObject { get; } = new();
    public HttpStatusCode HttpStatusCode { get; }

    public LinksDeleteResultAction(DeletedObjectResponse delteResponse,
        RootObject<OriinLink> rootObject, HttpStatusCode httpStatusCode)
    {
        DelteResponse = delteResponse;
        RootObject = rootObject;
        HttpStatusCode = httpStatusCode;
    }
}
