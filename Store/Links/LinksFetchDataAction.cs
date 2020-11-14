namespace OriinDic.Store.Links
{
    public class LinksFetchDataAction
    {
        public string Token { get; init; } = string.Empty;
        public int SearchPageNr { get; init; } = 0;
        public long ItemsPerPage { get; init; } = 0;

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