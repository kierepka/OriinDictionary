namespace OriinDic.Store.Translations
{
    public class TranslationsFetchCommentsAction
    {
        public long TranslationId { get; }
        public string Token { get; }

        public TranslationsFetchCommentsAction(long translationId, string token)
        {
            TranslationId = translationId;
            Token = token;
        }
    }
}