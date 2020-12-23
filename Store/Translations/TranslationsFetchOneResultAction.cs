using OriinDic.Models;

using System.Net;

namespace OriinDic.Store.Translations
{
    public class TranslationsFetchOneResultAction
    {
        public Translation Translation { get; init; } = new();
        public HttpStatusCode ResultCode { get; init; } = HttpStatusCode.BadRequest;

        public TranslationsFetchOneResultAction(Translation translation, HttpStatusCode httpStatusCode)
        {
            Translation = translation;
            ResultCode = httpStatusCode;
        }
    }
}
