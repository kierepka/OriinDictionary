namespace OriinDic.Store.Links
{
    public class LinksDeleteAction
    {
        public string Token { get; }
        public long LinkId { get; }

        public LinksDeleteAction(long linkId, string token)
        {
            Token = token;
            LinkId = linkId;
        }
    }
}