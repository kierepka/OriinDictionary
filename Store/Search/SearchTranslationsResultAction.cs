using OriinDictionary7.Models;

using System.Net;

namespace OriinDictionary7.Store.Search;

public class SearchTranslationsResultAction
{
    public RootObject<ResultBaseTranslation> RootObject { get; init; } = new();

    public SearchTranslationsResultAction(RootObject<ResultBaseTranslation> rootObject,
        HttpStatusCode httpStatusCode)
    {
        RootObject = rootObject;
    }
}