using OriinDic.Models;

using System.Collections.Generic;

namespace OriinDic.Store.Languages
{
    public record LanguagesFetchDataStoreResultAction
    {
        public IEnumerable<Language> Languages { get; } = new List<Language>();

        public LanguagesFetchDataStoreResultAction(IEnumerable<Language> languages)
        {
            Languages = languages;
        }
    }
}
