namespace OriinDic.Store.Links
{
    public record LinksDeleteAction
    {
        public string Token { get; } = string.Empty;
        public long LinkId { get; }
        public string DeleteLinkMessage { get; }


        public LinksDeleteAction(long linkId, string token, string deleteLinkMessage)
        {
            Token = token;
            DeleteLinkMessage = deleteLinkMessage;
            LinkId = linkId;
          
        }
    }
}