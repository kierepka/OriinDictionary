namespace OriinDic.Store.Translations
{
    public class TranslationsFetch4EditAction
    {
        public long TranslationId { get; }
        public string Token { get; }

        public TranslationsFetch4EditAction(long translationId, string token)
        {
            TranslationId = translationId;
            Token = token;
        }
    }
}