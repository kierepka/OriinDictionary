using OriinDic.Models;

namespace OriinDic.Store.Translations
{
    public class TranslationsAddAction
    {
        public string Token { get; init; } = string.Empty;
        public Translation Translation { get; init; } = new Translation();

        public TranslationsAddAction(Translation translation, string token)
        {
            Token = token;
            Translation = translation;
        }
    }
}