using System.Collections.Generic;
using OriinDic.Models;

namespace OriinDic.Store.Translations
{
    public class TranslationsFetchBaseTermResultAction
    {
        public BaseTerm BaseTerm { get; init; } = new BaseTerm();

        public TranslationsFetchBaseTermResultAction(BaseTerm baseTerm)
        {
            BaseTerm = baseTerm;
        }
    }
}
