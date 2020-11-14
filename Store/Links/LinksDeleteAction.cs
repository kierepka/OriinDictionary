namespace OriinDic.Store.Links
{
    public class LinksDeleteAction
    {
        public string Token { get; init; } = string.Empty;
        public long LinkId { get; init; } = 0;

        public LinksDeleteAction(long linkId, string token)
        {
            Token = token;
            LinkId = linkId;
        }
    }
}