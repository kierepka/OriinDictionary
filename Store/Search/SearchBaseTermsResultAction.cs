using OriinDictionary7.Models;

using System.Net;

namespace OriinDictionary7.Store.Search;

public class SearchBaseTermsResultAction
{
    public RootObject<ResultBaseTranslation> RootObject { get; } = new();
    public HttpStatusCode ReturnCode { get; }

    public SearchBaseTermsResultAction(RootObject<ResultBaseTranslation> rootObject, HttpStatusCode returnCode)
    {
        RootObject = rootObject;
        ReturnCode = returnCode;
    }
}
