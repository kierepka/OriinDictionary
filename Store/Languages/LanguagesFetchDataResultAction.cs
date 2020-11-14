using System.Collections.Generic;
using OriinDic.Models;

namespace OriinDic.Store.Languages
{
    public class LanguagesFetchDataResultAction
    {
        public IEnumerable<Language> Languages { get; init; } = new List<Language>();

        public LanguagesFetchDataResultAction(IEnumerable<Language> languages)
        {
            Languages = languages;
        }
    }
}
