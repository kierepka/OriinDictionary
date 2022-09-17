using OriinDictionary7.Models;

namespace OriinDictionary7.Store.Languages;

public record LanguagesFetchDataResultAction
{
    public IEnumerable<Language> Languages { get; } = new List<Language>();

    public LanguagesFetchDataResultAction(IEnumerable<Language> languages)
    {
        Languages = languages;
    }
}
