using OriinDic.Models;

using System.Net;

namespace OriinDic.Store.Search
{
    public class SearchTranslationsResultAction
    {
        public RootObject<ResultBaseTranslation> RootObject { get; init; } = new();

        public SearchTranslationsResultAction(RootObject<ResultBaseTranslation> rootObject,
            HttpStatusCode httpStatusCode)
        {
            RootObject = rootObject;
        }
    }
}