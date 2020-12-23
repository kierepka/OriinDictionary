using OriinDic.Models;

using System.Collections.Generic;
using System.Net;

namespace OriinDic.Store.BaseTerms
{
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
}
