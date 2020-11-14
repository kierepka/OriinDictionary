using OriinDic.Models;

namespace OriinDic.Store.Comments
{
    public class CommentsFetchForTranslationResultAction
    {
        public RootObject<Comment> RootObject { get; init; } = new RootObject<Comment>();

        public CommentsFetchForTranslationResultAction(RootObject<Comment> rootObject)
        {
            RootObject = rootObject;
        }
    }
}
