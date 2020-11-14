using OriinDic.Models;

namespace OriinDic.Store.Translations
{
    public class TranslationsFetchOneResultAction
    {
        public Translation Translation { get; init; } = new Translation();

        public TranslationsFetchOneResultAction(Translation translation)
        {
            Translation = translation;
        }
    }
}
