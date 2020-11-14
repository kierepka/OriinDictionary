namespace OriinDic.Store.Translations
{
    public class TranslationsFetchOneAction
    {
        public long TranslationId { get; init; } = 0;

        public TranslationsFetchOneAction(long translationId)
        {
            TranslationId = translationId;
        }
    }
}