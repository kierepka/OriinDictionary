namespace OriinDic.Store.Translations
{
    public class TranslationsFetchCommentsAction
    {
        public long TranslationId { get; init; } = 0;
        public string Token { get; init; } = string.Empty;

        public TranslationsFetchCommentsAction(long translationId, string token)
        {
            TranslationId = translationId;
            Token = token;
        }
    }
}