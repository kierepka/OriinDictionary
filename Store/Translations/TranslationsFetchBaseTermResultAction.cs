using OriinDic.Models;

using System.Net;

namespace OriinDic.Store.Translations
{
    public class TranslationsFetchBaseTermResultAction
    {
        public ResultBaseTranslation BaseTranslation { get; init; } = new ResultBaseTranslation();
        public HttpStatusCode ResultCode { get; init; } = HttpStatusCode.BadRequest;

        public TranslationsFetchBaseTermResultAction(ResultBaseTranslation baseTranslation, HttpStatusCode httpStatusCode)
        {
            BaseTranslation = baseTranslation;
            ResultCode = httpStatusCode; 
        }
    }
}
