using System.Collections.Generic;
using OriinDic.Models;

namespace OriinDic.Store.Languages
{
    public record LanguagesFetchDataResultAction
    {
        public IEnumerable<Language> Languages { get; } = new List<Language>();

        public LanguagesFetchDataResultAction(IEnumerable<Language> languages)
        {
            Languages = languages;
        }
    }
}
