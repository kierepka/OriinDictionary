namespace OriinDic.Store.Users
{
    public record UsersFetchDataAction
    {
        public string Token { get; init; } = string.Empty;
        public int SearchPageNr { get; init; }
        public long ItemsPerPage { get; init; }

        public string UserFetchedMessage { get; } = string.Empty;

        public UsersFetchDataAction(string token, int searchPageNr, long itemsPerPage, string userFetchedMessage)
        {
            Token = token;
            SearchPageNr = searchPageNr;
            ItemsPerPage = itemsPerPage;
            UserFetchedMessage = userFetchedMessage;
        }


    }
}