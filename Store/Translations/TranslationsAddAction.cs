using OriinDic.Models;

namespace OriinDic.Store.Translations
{
    public class TranslationsAddAction
    {
        public string Token { get; }
        public Translation Translation { get; }

        public TranslationsAddAction(Translation translation, string token)
        {
            Token = token;
            Translation = translation;
        }
    }
}