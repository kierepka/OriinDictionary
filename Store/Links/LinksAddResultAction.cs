using OriinDictionary7.Models;

using System.Net;

namespace OriinDictionary7.Store.Links;

public record LinksAddResultAction
{
    public OriinLink Link { get; } = new();
    public HttpStatusCode HttpStatusCode { get; }
    public LinksAddResultAction(OriinLink link, HttpStatusCode httpStatusCode)
    {
        Link = link;
        HttpStatusCode = httpStatusCode;
    }
}
