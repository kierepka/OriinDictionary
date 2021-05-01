using OriinDic.Models;

namespace OriinDic.Store.Translations
{
    public record TranslationsUpdateAction
    {
        public long TranslationId { get; }
        public string Token { get; } = string.Empty;
        public Translation Translation { get; } = new();
        public string TranslationUpdateMessage { get; }

        public TranslationsUpdateAction(long translationId, Translation translation,
            string token, string translationUpdateMessage)
        {
            TranslationId = translationId;
            Token = token;
            TranslationUpdateMessage = translationUpdateMessage;
            Translation = translation;
        }
    }
}