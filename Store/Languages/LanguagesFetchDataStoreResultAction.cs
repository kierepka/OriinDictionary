using System.Collections.Generic;
using OriinDic.Models;

namespace OriinDic.Store.Languages
{
    public class LanguagesFetchDataStoreResultAction
    {
        public IEnumerable<Language> Languages { get; }

        public LanguagesFetchDataStoreResultAction(IEnumerable<Language> languages)
        {
            Languages = languages;
        }
    }
}
