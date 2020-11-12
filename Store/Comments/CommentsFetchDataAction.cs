namespace OriinDic.Store.Comments
{
    public class CommentsFetchDataAction
    {
        public string Token { get; }
        public int SearchPageNr { get; }
        public long ItemsPerPage { get; }

        
        public CommentsFetchDataAction(string token)
        {
            Token = token;

        }

        public CommentsFetchDataAction(string token, int searchPageNr, long itemsPerPage)
        {
            Token = token;
            SearchPageNr = searchPageNr;
            ItemsPerPage = itemsPerPage;
        }

        
    }
}