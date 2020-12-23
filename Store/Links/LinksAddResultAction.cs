using System.Net;
using OriinDic.Models;

namespace OriinDic.Store.Links
{
    public record LinksAddResultAction
    {
        public OriinLink Link { get; } = new();
        public HttpStatusCode HttpStatusCode { get; }
        public LinksAddResultAction(OriinLink link,  HttpStatusCode httpStatusCode)
        {
            Link = link;
            HttpStatusCode = httpStatusCode;
        }
    }
}
