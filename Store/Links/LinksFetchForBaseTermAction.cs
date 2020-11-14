namespace OriinDic.Store.Links
{
    public class LinksFetchForBaseTermAction
    {
        public long BaseTermId { get; init; } = 0;
        public string Token { get; init; } = string.Empty;


        public LinksFetchForBaseTermAction(long baseTermId, string token)
        {
            BaseTermId = baseTermId;
            Token = token;
        }
    }
}