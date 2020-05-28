namespace OriinDic.Store.Translations
{
    public class TranslationsFetchOneAction
    {
        public long TranslationId { get; }

        public TranslationsFetchOneAction(long translationId)
        {
            TranslationId = translationId;
        }
    }
}