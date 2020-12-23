using System.Collections.Generic;
using System.Net;

using OriinDic.Models;

namespace OriinDic.Store.Translations
{
    public class TranslationsFetchCommentsResultAction
    {
        public List<Comment> Comments { get; init; } = new();

        public HttpStatusCode ResultCode { get; init; } = HttpStatusCode.BadRequest;

        public TranslationsFetchCommentsResultAction(List<Comment> comments, HttpStatusCode httpStatusCode)
        {
            Comments = comments;
            ResultCode = httpStatusCode;
        }
    }
}
