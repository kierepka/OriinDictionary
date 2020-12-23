namespace OriinDic.Store.Translations
{
    public record TranslationsApproveAction
    {
        public string Token { get; } = string.Empty;
        public long TranslationId { get; }

        public string TranslationApproved { get; } = string.Empty;

        public TranslationsApproveAction(long translationId, string token, string translationApproved)
        {
            Token = token;
            TranslationApproved = translationApproved;
            TranslationId = translationId;
        }
    }
}