using OriinDic.Models;

namespace OriinDic.Store.Translations
{
    public class TranslationsUpdateAction
    {
        public long TranslationId { get; init; } = 0;
        public string Token { get; init; } = string.Empty;
        public Translation Translation { get; init; } = new Translation();

        public TranslationsUpdateAction(long translationId, Translation translation, string token)
        {
            TranslationId = translationId;
            Token = token;
            Translation = translation;
        }
    }
}