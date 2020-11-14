namespace OriinDic.Store.Users
{
    public class UsersFetchDataAction
    {
        public string Token { get; init; } = string.Empty;
        public int SearchPageNr { get; init; } = 0;
        public long ItemsPerPage { get; init; } = 0;

        

        public UsersFetchDataAction(string token, int searchPageNr, long itemsPerPage)
        {
            Token = token;
            SearchPageNr = searchPageNr;
            ItemsPerPage = itemsPerPage;
        }

        
    }
}