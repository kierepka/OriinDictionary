using OriinDic.Models;

namespace OriinDic.Store.Translations
{
    public class TranslationsFetchBaseTermResultAction
    {
        public BaseTerm BaseTerm { get; }

        public TranslationsFetchBaseTermResultAction(BaseTerm baseTerm)
        {
            BaseTerm = baseTerm;
        }
    }
}
