using OriinDic.Models;

using System.Net;

namespace OriinDic.Store.Translations
{
    public class TranslationsAddResultAction
    {
        public Translation Translation { get; init; } = new Translation();
        public HttpStatusCode ResultCode { get; init; } = HttpStatusCode.BadRequest;

        public TranslationsAddResultAction(Translation translation, HttpStatusCode resultCode)
        {
            Translation = translation;
            ResultCode = resultCode;
        }
    }
}
