namespace OriinDic.Store.Links
{
    public record LinksFetchDataAction
    {
        public int SearchPageNr { get; }
        public long ItemsPerPage { get; }
        public string LinkFetchedMessage { get; }


        public LinksFetchDataAction(int searchPageNr, long itemsPerPage, string linkFetchedMessage)
        {
            SearchPageNr = searchPageNr;
            ItemsPerPage = itemsPerPage;
            LinkFetchedMessage = linkFetchedMessage;
        }

        
    }
}