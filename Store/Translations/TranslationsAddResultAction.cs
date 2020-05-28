using OriinDic.Models;

namespace OriinDic.Store.Translations
{
    public class TranslationsAddResultAction
    {
        public Translation Translation { get; }

        public TranslationsAddResultAction(Translation translation)
        {
            Translation = translation;
        }
    }
}
