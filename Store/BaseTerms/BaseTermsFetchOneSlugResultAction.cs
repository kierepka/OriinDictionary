using OriinDic.Models;

using System.Collections.Generic;
using System.Net;

namespace OriinDic.Store.BaseTerms
{
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
}
