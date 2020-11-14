using OriinDic.Models;

namespace OriinDic.Store.Links
{
    public class LinksAddAction
    {
        public OriinLink Link { get; init; } = new OriinLink();
        public string Token { get; init; } = string.Empty;

        public LinksAddAction(OriinLink link, string token)
        {
            Link = link;
            Token = token;
        }
    }
}