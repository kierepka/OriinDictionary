using OriinDictionary7.Models;

using System.Net;

namespace OriinDictionary7.Store.Translations;

public class TranslationsApproveResultAction
{
    public HttpStatusCode ResultCode { get; init; } = HttpStatusCode.BadRequest;
    public Translation Translation { get; init; } = new();

    public TranslationsApproveResultAction(HttpStatusCode resultCode, Translation translation)
    {
        ResultCode = resultCode;
        Translation = translation;

    }
}
