using OriinDic.Models;

using System.Net;

namespace OriinDic.Store.Translations
{
    public record TranslationsAddResultAction
    {
        public Translation Translation { get; } = new();
        public HttpStatusCode ResultCode { get; } = HttpStatusCode.BadRequest;

        public TranslationsAddResultAction(Translation translation, HttpStatusCode resultCode)
        {
            Translation = translation;
            ResultCode = resultCode;
        }
    }
}
