namespace OriinDic.Store.Translations
{
    public class TranslationsFetch4EditAction
    {
        public long TranslationId { get; init; } = 0;
        public string Token { get; init; } = string.Empty;
        public string NoData { get; init; } = string.Empty;

        public TranslationsFetch4EditAction(long translationId, string token, string noData)
        {
            TranslationId = translationId;
            Token = token;
            NoData = noData;
        }
    }
}