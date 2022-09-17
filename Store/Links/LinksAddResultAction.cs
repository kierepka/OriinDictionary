using OriinDic.Models;

using System.Net;

namespace OriinDic.Store.Links
{
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
}
