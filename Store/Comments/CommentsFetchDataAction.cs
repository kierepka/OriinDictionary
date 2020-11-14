namespace OriinDic.Store.Comments
{
    public class CommentsFetchDataAction
    {
        public string Token { get; init; } = string.Empty;
        public int SearchPageNr { get; init; } = 0;
        public long ItemsPerPage { get; init; } = 0;

        
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