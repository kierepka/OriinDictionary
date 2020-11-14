namespace OriinDic.Store.Comments
{
    public class CommentsFetchForTranslationAction
    {
        public long TranslationId { get; init; } = 0;
        public string Token { get; init; } = string.Empty;


        public CommentsFetchForTranslationAction(long translationId, string token)
        {
            TranslationId = translationId;
            Token = token;
        }
    }
}