using OriinDic.Models;

namespace OriinDic.Store.Links
{
    public class LinksAddResultAction
    {
        public OriinLink Link { get; }
        public string StatusCode { get; }

        public LinksAddResultAction(OriinLink link, string statusCode)
        {
            Link = link;
            StatusCode = statusCode;
        }
    }
}
