using OriinDic.Models;

namespace OriinDic.Store.Comments
{
    public class CommentsAddAction
    {
        public string Token { get; }
        public Comment Comment{ get; }

        public CommentsAddAction(Comment comment, string token)
        {
            Token = token;
            Comment = comment;
        }
    }
}