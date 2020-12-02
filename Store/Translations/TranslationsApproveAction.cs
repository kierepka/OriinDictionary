namespace OriinDic.Store.Translations
{
    public class TranslationsAproveAction
    {
        public string Token { get; init; } = string.Empty;
        public long TranslationId { get; init; } = 0;

        public TranslationsAproveAction(long translationId, string token)
        {
            Token = token;
            TranslationId = translationId;
        }
    }
}