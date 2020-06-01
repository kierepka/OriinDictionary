namespace OriinDic.Store.Links
{
    public class LinksFetchDataAction
    {
        public string Token { get; }
        public int SearchPageNr { get; }
        public long ItemsPerPage { get; }

        public LinksFetchDataAction(string token)
        {
            Token = token;
        }

        public LinksFetchDataAction(string token, int searchPageNr, long itemsPerPage)
        {
            Token = token;
            SearchPageNr = searchPageNr;
            ItemsPerPage = itemsPerPage;
        }

        
    }
}