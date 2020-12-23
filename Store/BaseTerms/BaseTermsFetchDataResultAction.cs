using System.Net;
using OriinDic.Models;

namespace OriinDic.Store.BaseTerms
{
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
}
