namespace OriinDic.Store.Users
{
    public class UsersFetchDataAction
    {
        public string Token { get; }
        public int SearchPageNr { get; }
        public long ItemsPerPage { get; }

        

        public UsersFetchDataAction(string token, int searchPageNr, int itemsPerPage)
        {
            Token = token;
            SearchPageNr = searchPageNr;
            ItemsPerPage = itemsPerPage;
        }

        
    }
}