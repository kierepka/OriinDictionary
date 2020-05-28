using OriinDic.Models;

namespace OriinDic.Store.Comments
{
    public class CommentsFetchForTranslationResultAction
    {
        public RootObject<Comment> RootObject { get; }

        public CommentsFetchForTranslationResultAction(RootObject<Comment> rootObject)
        {
            RootObject = rootObject;
        }
    }
}
