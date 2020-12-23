namespace OriinDic.Store.Translations
{
    public record TranslationsFetchOneAction
    {
        public long TranslationId { get; }
        public string FetchOneSuccessMessage { get; } = string.Empty;

        public TranslationsFetchOneAction(long translationId, string fetchOneSuccessMessage)
        {
            TranslationId = translationId;
            FetchOneSuccessMessage = fetchOneSuccessMessage;
        }
    }
}