using OriinDic.Models;

namespace OriinDic.Store.Links
{
    public class LinksAddResultAction
    {
        public OriinLink Link { get; init; } = new OriinLink();
        public string StatusCode { get; init; } = string.Empty;

        public LinksAddResultAction(OriinLink link, string statusCode)
        {
            Link = link;
            StatusCode = statusCode;
        }
    }
}
