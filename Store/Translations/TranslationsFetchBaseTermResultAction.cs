using OriinDictionary7.Models;

using System.Net;

namespace OriinDictionary7.Store.Translations;

public record TranslationsFetchBaseTermResultAction
{
    public ResultBaseTranslation BaseTranslation { get; } = new();
    public HttpStatusCode ResultCode { get; } = HttpStatusCode.BadRequest;

    public TranslationsFetchBaseTermResultAction(ResultBaseTranslation baseTranslation, HttpStatusCode httpStatusCode)
    {
        BaseTranslation = baseTranslation;
        ResultCode = httpStatusCode;
    }
}
