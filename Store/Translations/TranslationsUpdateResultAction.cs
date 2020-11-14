using OriinDic.Models;

namespace OriinDic.Store.Translations
{
    public class TranslationsUpdateResultAction
    {
        public Translation Translation { get; init; } = new Translation();

        public TranslationsUpdateResultAction(Translation translation)
        {
            Translation = translation;
        }
    }
}
