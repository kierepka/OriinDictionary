using OriinDic.Models;

using System.Collections.Generic;

namespace OriinDic.Store.BaseTerms
{
    public class BaseTermsFetchOneSlugResultAction
    {
        public BaseTerm BaseTerm { get; init; } = new BaseTerm();

        public List<OriinLink> Links { get; init; } = new List<OriinLink>();

        public BaseTermsFetchOneSlugResultAction(BaseTerm baseTerm, List<OriinLink> links)
        {
            BaseTerm = baseTerm;
            Links = links;
        }
    }
}
