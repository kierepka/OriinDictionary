namespace OriinDic.Store.Translations
{
    public class TranslationsFetchBaseTermAction
    {
        public long BaseTermId { get; init; } = 0;

        public TranslationsFetchBaseTermAction(long baseTermId)
        {
            BaseTermId = baseTermId;
            
        }
    }
}