using OriinDic.Models;

namespace OriinDic.Store.Translations
{
    public class TranslationsFetchBaseTermResultAction
    {
        public ResultBaseTranslation BaseTranslation { get; init; } = new ResultBaseTranslation();

        public TranslationsFetchBaseTermResultAction(ResultBaseTranslation baseTranslation)
        {
            BaseTranslation = baseTranslation;
        }
    }
}
