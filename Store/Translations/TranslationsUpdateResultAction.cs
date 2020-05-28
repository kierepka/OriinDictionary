using OriinDic.Models;

namespace OriinDic.Store.Translations
{
    public class TranslationsUpdateResultAction
    {
        public Translation Translation { get; }

        public TranslationsUpdateResultAction(Translation translation)
        {
            Translation = translation;
        }
    }
}
