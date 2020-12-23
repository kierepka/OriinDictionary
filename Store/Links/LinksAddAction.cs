using OriinDic.Models;

namespace OriinDic.Store.Links
{
    public record LinksAddAction
    {
        public OriinLink Link { get; } = new();
        public string Token { get; } = string.Empty;
        public string LinksAddedMessage { get; }

        public LinksAddAction(OriinLink link, string token, string linksAddedMessage)
        {
            Link = link;
            Token = token;
            LinksAddedMessage = linksAddedMessage;
        }
    }
}