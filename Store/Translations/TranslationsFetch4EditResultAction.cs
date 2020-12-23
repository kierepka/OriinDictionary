using System.Collections.Generic;
using System.Net;

using OriinDic.Models;

namespace OriinDic.Store.Translations
{
    public class TranslationsFetch4EditResultAction
    {
        public Translation Translation { get; init; } = new();
        public BaseTerm BaseTerm { get; init; } = new();
        public List<OriinLink> Links { get; init; } = new();
        public List<Comment> Comments { get; init; } = new();

        public HttpStatusCode ResultCode { get; init; } = HttpStatusCode.BadRequest;

        public TranslationsFetch4EditResultAction(Translation translation, BaseTerm baseTerm,
            List<OriinLink> links, List<Comment> comments, HttpStatusCode httpStatusCode)
        {
            Translation = translation;
            BaseTerm = baseTerm;
            Links = links;
            Comments = comments;
            ResultCode = httpStatusCode;
        }
    }
}
