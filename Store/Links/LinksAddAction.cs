using OriinDic.Models;

namespace OriinDic.Store.Links
{
    public class LinksAddAction
    {
        public OriinLink Link { get; }
        public string Token { get; }

        public LinksAddAction(OriinLink link, string token)
        {
            Link = link;
            Token = token;
        }
    }
}