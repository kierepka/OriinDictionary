using OriinDic.Models;

using System.Net;

namespace OriinDic.Store.Translations
{
    public class TranslationsFetchDataResultAction
    {
        public RootObject<ResultBaseTranslation> RootObject { get; init; } = new();
        public HttpStatusCode ResultCode { get; init; } = HttpStatusCode.BadRequest;
        public TranslationsFetchDataResultAction(RootObject<ResultBaseTranslation> rootObject, HttpStatusCode httpStatusCode)
        {
            RootObject = rootObject;
            ResultCode = httpStatusCode;
        }
    }
}
