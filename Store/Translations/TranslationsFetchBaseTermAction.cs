namespace OriinDic.Store.Translations
{
    public class TranslationsFetchBaseTermAction
    {
        public long BaseTermId { get; }

        public TranslationsFetchBaseTermAction(long baseTermId)
        {
            BaseTermId = baseTermId;
            
        }
    }
}