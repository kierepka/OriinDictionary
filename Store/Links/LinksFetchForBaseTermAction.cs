namespace OriinDic.Store.Links
{
    public class LinksFetchForBaseTermAction
    {
        public long BaseTermId { get; }
        public string Token { get; }


        public LinksFetchForBaseTermAction(long baseTermId, string token)
        {
            BaseTermId = baseTermId;
            Token = token;
        }
    }
}