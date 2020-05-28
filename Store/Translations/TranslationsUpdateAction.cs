using OriinDic.Models;

namespace OriinDic.Store.Translations
{
    public class TranslationsUpdateAction
    {
        public long TranslationId { get; }
        public string Token { get; }
        public Translation Translation { get; }

        public TranslationsUpdateAction(long translationId, Translation translation, string token)
        {
            TranslationId = translationId;
            Token = token;
            Translation = translation;
        }
    }
}