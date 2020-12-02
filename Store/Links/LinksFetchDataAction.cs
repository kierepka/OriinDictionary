namespace OriinDic.Store.Links
{
    public class LinksFetchDataAction
    {
        public int SearchPageNr { get; init; } = 0;
        public long ItemsPerPage { get; init; } = 0;


        public LinksFetchDataAction(int searchPageNr, long itemsPerPage)
        {
            SearchPageNr = searchPageNr;
            ItemsPerPage = itemsPerPage;
        }

        
    }
}