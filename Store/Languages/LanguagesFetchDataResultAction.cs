using System.Collections.Generic;
using OriinDic.Models;

namespace OriinDic.Store.Languages
{
    public class LanguagesFetchDataResultAction
    {
        public IEnumerable<Language> Languages { get; }

        public LanguagesFetchDataResultAction(IEnumerable<Language> languages)
        {
            Languages = languages;
        }
    }
}
