namespace OriinDic.Store.Translations
{
    public class TranslationsFetch4EditAction
    {
        public long TranslationId { get; private set; }
        public string Token { get; private set; }
        public string NoData { get; private set; }

        public TranslationsFetch4EditAction(long translationId, string token, string noData)
        {
            TranslationId = translationId;
            Token = token;
            NoData = noData;
        }
    }
}