using OriinDic.Models;

namespace OriinDic.Store.Comments
{
    public record CommentsAddAction
    {
        public string Token { get; } = string.Empty;
        public Comment Comment { get; } = new();
        public string AddDataSuccessMessage { get; }

        public CommentsAddAction(Comment comment, string token, string addDataSuccessMessage)
        {
            Token = token;
            AddDataSuccessMessage = addDataSuccessMessage;
            Comment = comment;
        }
    }
}