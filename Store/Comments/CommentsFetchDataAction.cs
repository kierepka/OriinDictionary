using OriinDic.Helpers;

namespace OriinDic.Store.Comments
{
    public record CommentsFetchDataAction
    {
        public string Token { get; } = string.Empty;
        public int SearchPageNr { get; }
        public long ItemsPerPage { get; }
        public string CommentsLoadedMessage { get; }


        public CommentsFetchDataAction(string token, string commentsLoadedMessage)
            => (Token, SearchPageNr, ItemsPerPage, CommentsLoadedMessage) =
                (token, 0, Const.DefaultItemsPerPage, commentsLoadedMessage);


        public CommentsFetchDataAction(string token, int searchPageNr, long itemsPerPage, string commentsLoadedMessage)
        {
            Token = token;
            SearchPageNr = searchPageNr;
            ItemsPerPage = itemsPerPage;
            CommentsLoadedMessage = commentsLoadedMessage;
        }


    }
}