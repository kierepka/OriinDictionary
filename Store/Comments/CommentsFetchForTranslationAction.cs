namespace OriinDic.Store.Comments
{
    public class CommentsFetchForTranslationAction
    {
        public long TranslationId { get; }
        public string Token { get; }


        public CommentsFetchForTranslationAction(long translationId, string token)
        {
            TranslationId = translationId;
            Token = token;
        }
    }
}