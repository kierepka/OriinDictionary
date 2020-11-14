using OriinDic.Models;

namespace OriinDic.Store.Translations
{
    public class TranslationsAddResultAction
    {
        public Translation Translation { get; init; } = new Translation();

        public TranslationsAddResultAction(Translation translation)
        {
            Translation = translation;
        }
    }
}
