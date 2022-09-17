using OriinDictionary7.Models;

namespace OriinDictionary7.Store.Languages;

public record LanguagesFetchDataStoreResultAction
{
    public IEnumerable<Language> Languages { get; } = new List<Language>();

    public LanguagesFetchDataStoreResultAction(IEnumerable<Language> languages)
    {
        Languages = languages;
    }
}
