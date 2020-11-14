using OriinDic.Models;

using System.Collections.Generic;

namespace OriinDic.Store.BaseTerms
{
    public class BaseTermsFetchOneResultAction
    {
        public ResultBaseTranslation BaseTranslation { get; init; } = new ResultBaseTranslation();
        public List<OriinLink> Links { get; init; } = new List<OriinLink>();
        public BaseTermsFetchOneResultAction(ResultBaseTranslation baseTranslation, List<OriinLink> links)
        {
            BaseTranslation = baseTranslation;
            Links = links;
        }
    }
}
